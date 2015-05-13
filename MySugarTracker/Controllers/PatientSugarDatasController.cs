using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using MySugarTracker.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MySugarTracker.ViewModels;


namespace MySugarTracker.Controllers
{
    public class PatientSugarDatasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PatientSugarDatas
        public ActionResult Index()
        {
            var myId = User.Identity.GetUserId();
            var sugarData = from s in db.PatientSugarDatas select s;
            sugarData = sugarData.Where(s => s.UserID == myId );
            sugarData = sugarData.OrderByDescending(s => s.dateTime);
            var mySugarList = sugarData.ToList();
            return View(mySugarList);
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
            var MyId = User.Identity.GetUserId();
            var myManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = myManager.FindById(MyId);
            ViewBag.LastName = currentUser.LastName;
            ViewBag.FirstName = currentUser.FirstName;
            var sugarData = new PatientSugarData();
            sugarData.dateTime = DateTime.Now;
            return View(sugarData);
        }

        // POST: PatientSugarDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
  //      public ActionResult Create([Bind(Include = "PatientSugarDataID,UserID,patientSugarReading,dateTime")] PatientSugarData patientSugarData)
        public ActionResult Create([Bind(Include = "PatientSugarDataID,patientSugarReading,dateTime")] PatientSugarData patientSugarData)
        {
            if (ModelState.IsValid)
            {
                var MyId = User.Identity.GetUserId();
                var myManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = myManager.FindById(MyId);       
                patientSugarData.UserID = MyId;
                db.PatientSugarDatas.Add(patientSugarData);
                db.SaveChanges();
                
                var PatientCompare= (from u in db.Patients where u.UserID == MyId select new PatientUser
                {
                    HighAlert= u.HighAlert,
                    LowAlert= u.LowAlert,
                    FirstName= currentUser.FirstName,
                    LastName= currentUser.LastName,
                  
                }).Single() ;

                if (patientSugarData.patientSugarReading > PatientCompare.HighAlert || patientSugarData.patientSugarReading < PatientCompare.LowAlert)
                {
                    var MyMessage = new TextMsg();
                    var AlertMessage = "Patient " + PatientCompare.FirstName + " " + PatientCompare.LastName + " had a bloodsugar reading of " + patientSugarData.patientSugarReading;
                    MyMessage.SendMessage(AlertMessage, "2483963923");
                    MyMessage.SendMessage(AlertMessage, "2696016251");
                }
                                    

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
