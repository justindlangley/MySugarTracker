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

            if (patient.Female == true)
            {
                ViewBag.Gender = "Female";
            }
            else
            {
                ViewBag.Gender = "Male";
            }
            // get last six weeks data for graph
            var sixWeeksAgo = new DateTime();
            sixWeeksAgo = DateTime.Today.AddDays(-42);
            var graphData = from d in db.PatientSugarDatas select d;
            graphData = graphData.Where((d => d.UserID == myId && d.dateTime >= sixWeeksAgo));
            graphData = graphData.OrderBy(d => d.dateTime);
            var xdata = graphData.Select(x => x.dateTime).ToArray();
            var ydata = graphData.AsEnumerable().Select(y => new object[] { y.patientSugarReading }).ToArray();

            var Graph = new SugarGraph();
            var ViewGraph = Graph.CreateSugarChart(xdata, ydata, patient.LowAlert, patient.HighAlert);
            patient.MyChart = ViewGraph;

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
            Patient patview = db.Patients.Find(id);
            ApplicationUser patuser = db.Users.Find(id);


            if (patview == null)
            {
                return HttpNotFound();
            }

                            
                           var patient = new PatientUser();
                           //patient.UserID = patview.UserID;
                               patient.FirstName = patuser.FirstName;
                               patient.LastName = patuser.LastName;
                               patient.PhoneNumber = patuser.PhoneNumber;
                               patient.Email = patuser.Email;                             
                               patient.BirthDate = patview.BirthDate;
                               patient.CardioVascularDisease = patview.CardioVascularDisease;
                               patient.HighBloodPressure = patview.HighBloodPressure;
                               patient.Female = patview.Female;
                               patient.ThyroidDisease = patview.ThyroidDisease;
                               patient.HeightInInches = patview.HeightInInches;
                               patient.WeightInPounds = patview.WeightInPounds;
                               patient.Pregnant = patview.Pregnant;
                               patient.SMSPref = patview.SMSpref;
                               patient.EmailPref = patview.EmailPref;
                               patient.HighAlert = patview.HighAlert;
                               patient.LowAlert = patview.LowAlert;
                               patient.TestTime1 = patview.TestTime1;
                               patient.TestTime2 = patview.TestTime2;
                               patient.TestTime3 = patview.TestTime3;
                               patient.TestTime4 = patview.TestTime4;
                               
            // get last six weeks data for graph
            var sixWeeksAgo = new DateTime();
            sixWeeksAgo = DateTime.Today.AddDays(-42);
            var graphData = from d in db.PatientSugarDatas select d;
            graphData = graphData.Where((d => d.UserID == id && d.dateTime >= sixWeeksAgo));
            graphData = graphData.OrderBy(d => d.dateTime);
            var xdata = graphData.Select(x => x.dateTime).ToArray();
            var ydata = graphData.AsEnumerable().Select(y => new object[] { y.patientSugarReading }).ToArray();

            var Graph = new SugarGraph();
            var ViewGraph = Graph.CreateSugarChart(xdata, ydata, patient.LowAlert, patient.HighAlert);
            patient.MyChart = ViewGraph;

            //if (ModelState.IsValid)
            //{
            //    db.Entry(patview).State = EntityState.Modified;
            //    db.SaveChanges();
            //    db.Entry(patuser).State = EntityState.Modified;
            //    db.SaveChanges();
            //}
            return View(patient);

        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FirstName,LastName,PhoneNumber,Email,UserID,BirthDate,CardioVascularDisease,HighBloodPressure,ThyroidDisease,Female,Pregnant,EmailPref,SMSpref,LowAlert,HighAlert,TestTime1,TestTime2,TestTime3,TestTime4,WeightInPounds,HeightInInches")] PatientUser patientUser, string id)
        {
            if (ModelState.IsValid)
            {
                var myId = User.Identity.GetUserId();
                ApplicationUser cmuser = db.Users.Find(myId);
                var cmtype = cmuser.Role;

                Patient patview = db.Patients.Find(id);
                ApplicationUser patuser = db.Users.Find(id);
                
                    patuser.FirstName = patientUser.FirstName;
                    patuser.LastName = patientUser.LastName;
                    patuser.PhoneNumber = patientUser.PhoneNumber;
                    patuser.Email = patientUser.Email;
                    patview.BirthDate = patientUser.BirthDate;
                    patview.CardioVascularDisease = patientUser.CardioVascularDisease;
                    patview.HighBloodPressure = patientUser.HighBloodPressure;
                    patview.Female = patientUser.Female;
                    patview.ThyroidDisease = patientUser.ThyroidDisease;
                    patview.HeightInInches = patientUser.HeightInInches;
                    patview.WeightInPounds = patientUser.WeightInPounds;
                    patview.Pregnant = patientUser.Pregnant;
                    patview.SMSpref = patientUser.SMSPref;
                    patview.EmailPref = patientUser.EmailPref;
                    patview.HighAlert = patientUser.HighAlert;
                    patview.LowAlert = patientUser.LowAlert;
                    patview.TestTime1 = DateTime.Now;
                    patview.TestTime2 = DateTime.Now;
                    patview.TestTime3 = DateTime.Now;
                    patview.TestTime4 = DateTime.Now;
                    //  };
                    // Save the Patient object back in the database.
                    //db.Entry(patuser).State = EntityState.Modified;
                    db.Entry(patview).State = EntityState.Modified;
                db.SaveChanges();
                if (cmtype == "D")
                {
                    return RedirectToAction("../Doctor/Index");
                }
                else
                {
                    return RedirectToAction("../CaseManager/Index");
                }
                }
                return View(patientUser);
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
