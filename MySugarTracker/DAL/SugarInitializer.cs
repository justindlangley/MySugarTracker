using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MySugarTracker.Models;

namespace MySugarTracker.DAL
{
    public class SugarInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SugarContext>
    {
        protected override void Seed(SugarContext context)
        {
            var users = new List<User>
            {
            new User {FirstName="Daniel", LastName="Von Huffinstuff", Email="doctordan@dmc.net", PhoneNumber=3139644114, Role='D'},
            new User {FirstName="Robert", LastName="Baker", Email="rbaker@dmc.net", PhoneNumber=3139635533, Role='D' },
            new User {FirstName="Anthony", LastName="Filibustder", Email="afilibuster@dmc.net", PhoneNumber=3139612713, Role='D' },
            new User {FirstName="Spencer", LastName="Sterling", Email="ssterling@dmc.net", PhoneNumber=3138412005, Role='D'},
            new User {FirstName="Frank", LastName="Jones", Email="fjones@dmc.net", PhoneNumber=3132234567, Role='C'},
            new User {FirstName="Belinda", LastName="Johnson", Email="bjohnson@dmc.net", PhoneNumber=3132247654, Role='C'},
            new User {FirstName="Zaul", LastName="Barajas", Email="zbarajas@dmc.net", PhoneNumber=3132256890, Role='C'},
            new User {FirstName="Devin", LastName="Marsh", Email="dmarsh@yahoo.com", PhoneNumber=3135540955, Role='P'},
            new User {FirstName="Linda", LastName="Franklin", Email="lfranklin@gmail.com", PhoneNumber=3139953596, Role='C'},
            new User {FirstName="Christina", LastName="Placebo", Email="cplacebo@yahoo.com", PhoneNumber=3139619987, Role='P'}
            
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}