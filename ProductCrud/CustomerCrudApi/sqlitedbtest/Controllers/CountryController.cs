using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sqlitedbtest.Models;

namespace sqlitedbtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly DataContext context;
        public CountryController(DataContext context)
        {
            this.context = context;

        }
        [HttpGet]
        public async Task<IEnumerable<Country>> GetCountries()
        {
            return await context.Countries.ToListAsync();
        }
    }
}