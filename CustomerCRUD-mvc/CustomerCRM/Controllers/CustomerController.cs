using CustomerCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using CustomerCRM.ViewModels;

namespace CustomerCRM.Controllers
{
    public class CustomerController : Controller
    {
        DataContext context = new DataContext();
        
        // GET: Customer
        public ActionResult Index()
        {

            var customers = context.Customers.Include(c=>c.Country).ToList().Where(c=>c.IsActive==true);
                
                
            return View(customers);
        }

        public ActionResult Create()
        {
            var countries = context.Countries.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Countries = countries
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.FirstName = customer.FirstName;
                customerInDb.LastName = customer.LastName;
                customerInDb.Email = customer.Email;
                customerInDb.MobileNumber = customer.MobileNumber;
                customerInDb.Gender = customer.Gender;
                customerInDb.DOB = customer.DOB;
                customerInDb.Address = customer.Address;
                customerInDb.CountryId = customer.CountryId;
            }
         
            context.SaveChanges();

             return RedirectToAction("Index","Customer");
        } 

        public ActionResult Edit(int id)
        {
            var customer = context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                Countries = context.Countries.ToList()
            };
            return View("Create",viewModel);
        }

        public ActionResult Delete(int id)
        {
           
            context.Customers.Remove(context.Customers.Find(id));
            context.SaveChanges();

            return RedirectToAction("Index","Customer");
        }

        public ActionResult Display(int id)
        {
            var customer = context.Customers.Find(id);
            return View(customer);
        }
    }
}