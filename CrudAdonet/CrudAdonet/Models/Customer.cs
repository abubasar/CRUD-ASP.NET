using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudAdonet.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}