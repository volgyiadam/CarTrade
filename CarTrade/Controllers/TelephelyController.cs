﻿using System;
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

        public ActionResult Index(string searchtext = null)
        {
            if (searchtext == null)
            {
                return View(db.Telephelyek.ToList());
            }

            else
            {
                return View(db.Telephelyek.Where(x => x.cim.StartsWith(searchtext)));
            }
        }

        //
        // GET: /Telephely/Details/5

        //public ActionResult Details(int id = 0)
        //{
        //    Telephely telephely = db.Telephelyek.Find(id);
        //    if (telephely == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(telephely);
        //}
        public ActionResult Details(int id = 0)
        {
            Telephely telephely = db.Telephelyek.Find(id);
            if (telephely == null)
            {
                return HttpNotFound();
            }
            ViewBag.telep = telephely.irSzam + ", " + telephely.cim;
            ViewBag.foglalt = telephely.foglaltHelyek;
            return View(db.Autok.Where(x => x.telephelyId == telephely.id).ToList());
        }
        //
        // GET: /Telephely/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Telephely/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
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