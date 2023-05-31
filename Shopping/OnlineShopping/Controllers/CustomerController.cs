using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext datacontext)
        {
            this._context = datacontext;
        }

        // GET: api/Customer
        //Get all list of customer available in database
        [HttpGet]
        public async Task<ActionResult<IList<Customer>>> GetAllTask()
        {
            var cust = await _context.Customer.ToListAsync();
            return Ok(cust);
        }

        // POST: api/Customer
        //Add new customer to database
        [HttpPost]
        public async Task<IActionResult> AddNewCustomer([FromBody] Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);

        }
    }
}
