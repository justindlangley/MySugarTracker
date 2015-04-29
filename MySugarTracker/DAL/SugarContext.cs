using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySugarTracker.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace MySugarTracker.DAL
{
    public class SugarContext : DbContext
    {

        public SugarContext() : base("SugarContext")
        {
            public DbSet<Patient> Patients { get; set; }
            public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
 	 modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        }
    }
}