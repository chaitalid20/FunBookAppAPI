using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data;
using OnlineShopping.Models;
using Org.BouncyCastle.Utilities;

namespace OnlineShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext datacontext)
        {
            this._context = datacontext;
        }

        // GET: All the data present in Order table
        [HttpGet]
        public async Task<ActionResult<IList<Order>>> GetOrderDetials(int custId)
        {

            var orders = await _context.Order.Include(n => n.OrderList).Include(n => n.CustomerId).ToListAsync();

            return orders;
            //var order = await _context.Order.ToListAsync();
            //var details = _context.Order.Where(x => x.CustomerId == custId).ToList();

            //return Ok(details);
        }



        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody] List<Cart> cartItems, int userId)
        {
            var orderDetails = new Order()
            {
                CustomerId = userId
            };
            await _context.Order.AddAsync(orderDetails);
            await _context.SaveChangesAsync();

            foreach (var item in cartItems)
            {
                var orderItem = new OrderItems()
                {
                    //CustomerId = item.CartItem.customerId,
                    OrderId = orderDetails.Id,
                    ProductId = item.CartItem.ProductListId

                };

                await _context.OrderItems.AddAsync(orderItem);
                var product = await _context.ProductList.Where(x => x.Id == orderItem.ProductId).ToListAsync();
                foreach (var prod in product)
                {
                    if (prod.ProductTypeId == 3)
                    {
                        var call = UpdateCustomer(userId);
                    }
                }
                   await _context.SaveChangesAsync();
            }
            return Ok("Successful");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCustomer(int id)
        {
            var existingCust = await _context.Customer.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCust != null)
            {
                existingCust.IsMembership = true;
                await _context.SaveChangesAsync();
                return Ok(existingCust);
            }
            return NotFound("Task not Found");

        }

    }

}
