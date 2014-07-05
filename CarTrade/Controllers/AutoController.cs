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
    public class AutoController : Controller
    {
        private CarTradeDb db = new CarTradeDb();

        //
        // GET: /Auto/

        public ActionResult Index()
        {
            return View(db.Autok.ToList());
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
            return View(auto);
        }

        //
        // GET: /Auto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Auto/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Auto auto)
        {
            if (ModelState.IsValid)
            {
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
            return View(auto);
        }

        //
        // POST: /Auto/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Auto auto)
        {
            if (ModelState.IsValid)
            {
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