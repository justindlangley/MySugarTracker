﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySugarTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using MySugarTracker.ViewModels;

namespace MySugarTracker.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        public ActionResult Index()
        { 
                    var myId = User.Identity.GetUserId();

            var patient = (from u in db.Users
                           join p in db.Patients on u.Id equals p.UserID
                           where u.Role == "P" && u.Id == myId
                           select new PatientUser
                           {
                               FirstName = u.FirstName,
                               LastName = u.LastName,
                               PhoneNumber = u.PhoneNumber,
                               Email = u.Email,
                               BirthDate = p.BirthDate,
                               CardioVascularDisease = p.CardioVascularDisease,
                               HighBloodPressure = p.HighBloodPressure,
                               Female = p.Female,
                               ThyroidDisease = p.ThyroidDisease,
                               HeightInInches = p.HeightInInches,
                               WeightInPounds = p.WeightInPounds,
                               Pregnant = p.Pregnant,
                               SMSPref = p.SMSpref,
                               EmailPref = p.EmailPref,
                               HighAlert = p.HighAlert,
                               LowAlert = p.LowAlert,
                               TestTime1 = p.TestTime1,
                               TestTime2 = p.TestTime2,
                               TestTime3 = p.TestTime3,
                               TestTime4 = p.TestTime4
                           }).SingleOrDefault();
            return View(patient);
        }

            

        // GET: Patients/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        //// GET: Patients/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "UserID,BirthDate,CardioVascularDisease,HighBloodPressure,ThyroidDisease,Female,Pregnant,EmailPref,SMSpref,LowAlert,HighAlert,TestTime1,TestTime2,TestTime3,TestTime4,WeightInPounds,HeightInInches")] Patient patient)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Patients.Add(patient);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(patient);
        //}

        // GET: Patients/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,BirthDate,CardioVascularDisease,HighBloodPressure,ThyroidDisease,Female,Pregnant,EmailPref,SMSpref,LowAlert,HighAlert,TestTime1,TestTime2,TestTime3,TestTime4,WeightInPounds,HeightInInches")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
