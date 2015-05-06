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
            new User {FirstName="Frank", LastName="Jones", Email="fjones@bcbs.com", PhoneNumber=3132234567, Role='C'},
            new User {FirstName="Belinda", LastName="Johnson", Email="bjohnson@bcbs.com", PhoneNumber=3132247654, Role='C'},
            new User {FirstName="Zaul", LastName="Barajas", Email="zbarajas@gmail.com", PhoneNumber=3132256890, Role='P'},
            new User {FirstName="Devin", LastName="Marsh", Email="dmarsh@yahoo.com", PhoneNumber=3135540955, Role='P'},
            new User {FirstName="Linda", LastName="Franklin", Email="lfranklin@gmail.com", PhoneNumber=3139953596, Role='P'},
            new User {FirstName="Christina", LastName="Placebo", Email="cplacebo@yahoo.com", PhoneNumber=3139619987, Role='P'},
            new User {FirstName="Spencer", LastName="Sterling", Email="ssterling@dmc.net", PhoneNumber=3138412005, Role='P'},
            new User {FirstName="Anthony", LastName="Filibustder", Email="afilibuster@yahoo.com", PhoneNumber=3139612713, Role='P' },
            new User {FirstName="John", LastName="Johnson", Email="jjohnson@gmail.com", PhoneNumber=3139612713, Role='P' },   
            new User {FirstName="Jason", LastName="Langster", Email="jlangster@yahoo.com", PhoneNumber=3139612713, Role='P' }, 
            new User {FirstName="Mark", LastName="Jensen", Email="markjenses@tds.net", PhoneNumber=2696016251, Role='P' },
            new User {FirstName="Justin", LastName="Langley", Email="justindlangley@gmail.com", PhoneNumber=3137780550, Role='P' },
            new User {FirstName="Raetoshia", LastName="Hardy", Email="rhard32@gmail.com", PhoneNumber=2483963923, Role='P' },
            
            };

            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();
        }
    }
}