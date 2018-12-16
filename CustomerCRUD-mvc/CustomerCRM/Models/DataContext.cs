using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerCRM.Models
{
    public class DataContext:DbContext
    {
        public DataContext() : base("Default") { }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Country> Countries { get; set; }



    }
}