using CustomerCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerCRM.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<Country> Countries { get; set; }
        public Customer Customer { get; set; }
    }
}