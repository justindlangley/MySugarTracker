using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MySugarTracker.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        //[Required]
        //public int UserID { get; set; }


        //Valid values are D=Dr P=Patient C=CaseManager
        

        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters")]
        public string LastName { get; set; }

        [Required]
        public string Role { get; set; }
        //[Required(ErrorMessage = "You must enter a valid email.")]
        //[EmailAddress]
        //public string Email { get; set; }

        //public long PhoneNumber { get; set; }

        //[Display(Name = "Full Name")]
        //public string FullName
        //{
        //    get { return FirstName + " " + LastName; }
        //}
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<MySugarTracker.Models.Patient> Patients { get; set; }

        public System.Data.Entity.DbSet<MySugarTracker.Models.PatientSugarData> PatientSugarDatas { get; set; }

        //public System.Data.Entity.DbSet<MySugarTracker.Models.ApplicationUser> Users { get; set; }

    }
}