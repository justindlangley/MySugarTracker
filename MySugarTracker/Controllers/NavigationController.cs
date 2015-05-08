using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MySugarTracker.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MySugarTracker.Controllers
{
    public class NavigationController : Controller
    {
        private ApplicationDbContext db;

        // GET: Navigation
        public ActionResult RoleSelect()
        {
            var myUserId = User.Identity.GetUserId();
            var myManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = myManager.FindById(myUserId);
            string myRole = currentUser.Role.ToString();            

            string returnUrl = "/Home/Index";

            switch (myRole)
            {
                case "P":
                    returnUrl = "/Patients/Index";
                    break;
                case "D":
                    returnUrl = "/Doctors/Index";
                    break;
                case "C":
                    returnUrl = "/CaseManagers/Index";
                    break;
                default:
                    break;
            }
            return Redirect(returnUrl);
        }
    }
}