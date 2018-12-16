using CrudAdonet.Dao;
using CrudAdonet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudAdonet.Controllers
{
    public class CustomerController : Controller
    {
        db context = new db();


        public ActionResult Index()
        {

            DataSet ds = context.ShowAllRecordsActive(true);
            ViewBag.cust = ds.Tables[0];
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection fc)
        {
            Customer customer = new Customer();
            customer.FirstName=fc["FirstName"];
            customer.LastName = fc["LastName"];
            customer.Email = fc["Email"];
            customer.MobileNumber = fc["MobileNumber"];
            customer.Gender = fc["Gender"];
            customer.DOB =Convert.ToDateTime(fc["DOB"]);
            customer.Address = fc["Address"];
            customer.CountryId =Convert.ToInt32(fc["CountryId"]);
            customer.IsActive =Convert.ToBoolean(fc["IsActive"]);
            context.AddRecord(customer);

            return RedirectToAction("Index","Customer");
        }
        public ActionResult Update(int id)
        {
            DataSet ds = context.ShowRecordById(id);
            ViewBag.custRecord = ds.Tables[0];
            return View();
        }
        [HttpPost]
        public ActionResult Update(int id, FormCollection fc)
        {
            Customer customer = new Customer();
            customer.Id = id;
            customer.FirstName = fc["FirstName"];
            customer.LastName = fc["LastName"];
            customer.Email = fc["Email"];
            customer.MobileNumber = fc["MobileNumber"];
            customer.Gender = fc["Gender"];
            customer.DOB = Convert.ToDateTime(fc["DOB"]);
            customer.Address = fc["Address"];
            customer.CountryId = Convert.ToInt32(fc["CountryId"]);
            customer.IsActive = Convert.ToBoolean(fc["IsActive"]);
            context.UpdateRecord(customer);
            
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Delete(int id)
        {
            context.DeleteRecord(id);

            return RedirectToAction("Index", "Customer");
        }

    }
}

/*
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

    return RedirectToAction("Index", "Customer");
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
    return View("Create", viewModel);
}

public ActionResult Delete(int id)
{

    context.Customers.Remove(context.Customers.Find(id));
    context.SaveChanges();

    return RedirectToAction("Index", "Customer");
}

public ActionResult Display(int id)
{
    var customer = context.Customers.Find(id);
    return View(customer);
} */

