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
    public class TelephelyController : Controller
    {
        private CarTradeDb db = new CarTradeDb();

        //
        // GET: /Telephely/

        public ActionResult Index()
        {
            return View(db.Telephelyek.ToList());
        }

        //
        // GET: /Telephely/Details/5

        public ActionResult Details(int id = 0)
        {
            Telephely telephely = db.Telephelyek.Find(id);
            if (telephely == null)
            {
                return HttpNotFound();
            }
            return View(telephely);
        }

        //
        // GET: /Telephely/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Telephely/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Telephely telephely)
        {
            if (ModelState.IsValid)
            {
                db.Telephelyek.Add(telephely);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(telephely);
        }

        //
        // GET: /Telephely/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Telephely telephely = db.Telephelyek.Find(id);
            if (telephely == null)
            {
                return HttpNotFound();
            }
            return View(telephely);
        }

        //
        // POST: /Telephely/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Telephely telephely)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telephely).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(telephely);
        }

        //
        // GET: /Telephely/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Telephely telephely = db.Telephelyek.Find(id);
            if (telephely == null)
            {
                return HttpNotFound();
            }
            return View(telephely);
        }

        //
        // POST: /Telephely/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Telephely telephely = db.Telephelyek.Find(id);
            db.Telephelyek.Remove(telephely);
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