using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sqlitedbtest.Models;

namespace sqlitedbtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext context;
        public CustomerController(DataContext context)
        {
            this.context = context;

        }
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            var customers= await context.Customers.Include(c => c.Country).ToListAsync();
            return customers;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var customer = await context.Customers.SingleOrDefaultAsync(c=>c.Id==id);
            return Ok(customer);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
            return Ok(customer);

        }

        // PUT api/values/5
        [HttpPut]
        public async Task<IActionResult> Put(Customer customer)
        {
            context.Entry(customer).State = EntityState.Modified;
            context.SaveChanges();
            return Ok(customer);
        }
         
            
        

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer=context.Customers.Find(id);
               context.Remove(customer);
            context.SaveChanges();

            return Ok();
           
        }
    }
}
