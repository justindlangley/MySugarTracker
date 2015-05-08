﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySugarTracker.Models;

namespace MySugarTracker.Controllers
{
    public class PatientSugarDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PatientSugarDatas
        public ActionResult Index()
        {
            return View(db.PatientSugarDatas.ToList());
        }

        // GET: PatientSugarDatas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientSugarData patientSugarData = db.PatientSugarDatas.Find(id);
            if (patientSugarData == null)
            {
                return HttpNotFound();
            }
            return View(patientSugarData);
        }

        // GET: PatientSugarDatas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientSugarDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PatientSugarDataID,UserID,patientSugarReading,dateTime")] PatientSugarData patientSugarData)
        {
            if (ModelState.IsValid)
            {
                db.PatientSugarDatas.Add(patientSugarData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patientSugarData);
        }

        // GET: PatientSugarDatas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientSugarData patientSugarData = db.PatientSugarDatas.Find(id);
            if (patientSugarData == null)
            {
                return HttpNotFound();
            }
            return View(patientSugarData);
        }

        // POST: PatientSugarDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PatientSugarDataID,UserID,patientSugarReading,dateTime")] PatientSugarData patientSugarData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patientSugarData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patientSugarData);
        }

        // GET: PatientSugarDatas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PatientSugarData patientSugarData = db.PatientSugarDatas.Find(id);
            if (patientSugarData == null)
            {
                return HttpNotFound();
            }
            return View(patientSugarData);
        }

        // POST: PatientSugarDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PatientSugarData patientSugarData = db.PatientSugarDatas.Find(id);
            db.PatientSugarDatas.Remove(patientSugarData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
