using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarTrade.Models;

namespace CarTrade.Controllers
{
    public class AutoController : Controller
    {
        private CarTradeDb db = new CarTradeDb();

        //
        // GET: /Auto/

        public ActionResult Index(string searchtext = null, int searchform = -1)
        {
            if (searchtext == null && searchform == -1)
            {
                return View(db.Autok.OrderBy(x => x.marka).ToList());
            }

            else
            {
                int ev = 0;
                if (searchform == 3)
                {
                    ev = Convert.ToInt16(searchtext);
                }
                switch (searchform)
                {
                    case 1: return View(db.Autok.Where(x => x.marka.StartsWith(searchtext)).OrderBy(x => x.marka).ToList());
                    case 2: return View(db.Autok.Where(x => x.tipus.StartsWith(searchtext)).OrderBy(x => x.marka).ToList());
                    case 3: return View(db.Autok.Where(x => x.evjarat==ev).OrderBy(x => x.marka).ToList());
                    default: return View(db.Autok.OrderBy(x => x.marka).ToList());
                }
            }
        }

        //
        // GET: /Auto/Details/5

        public ActionResult Details(int id = 0)
        {
            Auto auto = db.Autok.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            else
            {
                Telephely telep = db.Telephelyek.Find(auto.telephelyId);
                AutoView av = new AutoView(auto, telep);
                return View(av);
            }
            
        }

        //
        // GET: /Auto/Create

        public ActionResult Create()
        {
            ViewBag.telep = new SelectList(db.Telephelyek, "id", "cim");
            return View();
        }

        //
        // POST: /Auto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auto auto, int telep)
        {
            if (ModelState.IsValid)
            {
                auto.telephelyId = telep;
                db.Autok.Add(auto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(auto);
        }

        //
        // GET: /Auto/Edit/5

        public ActionResult Edit(int id = 0)
        {
            
            Auto auto = db.Autok.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            ViewBag.telep = new SelectList(db.Telephelyek, "id", "cim", auto.telephelyId);

            return View(auto);
        }

        //
        // POST: /Auto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Auto auto, int telep)
        {
            if (ModelState.IsValid)
            {
                auto.telephelyId = telep;
                db.Entry(auto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(auto);
        }

        //
        // GET: /Auto/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Auto auto = db.Autok.Find(id);
            if (auto == null)
            {
                return HttpNotFound();
            }
            return View(auto);
        }

        //
        // POST: /Auto/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Auto auto = db.Autok.Find(id);
            db.Autok.Remove(auto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}