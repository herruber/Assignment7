using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using Assignment7.Models;

namespace Assignment7.DataAccess
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public PersonContext() : base("ConnectionString")
        {

        }
    }
}