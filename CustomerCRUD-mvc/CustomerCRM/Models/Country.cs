﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerCRM.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Customer> Customers { get; set; }
    }
   
}