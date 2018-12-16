using System;
using System.Collections.Generic;


namespace CrudAdonet.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Customer> Customers { get; set; }
    }
}