using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using OnlineShopping.Data;
using OnlineShopping.Models;

namespace OnlineShopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {

        private readonly DataContext _context;

        public CartController(DataContext datacontext)
        {
            this._context = datacontext;
        }

       
        // GET: All the data present in card table
        [HttpGet]
        public async Task<ActionResult<IList<Cart>>> GetCart(int custId)
        {
            var cart = await _context.Cart.ToListAsync();
            var details = _context.CartItem.Where(x => x.customerId == custId).ToList();

            return Ok(details);
        }

       
        // Adds data in Cart Table in db
        [HttpPost]
        public async Task<IActionResult> AddCartItem([FromBody] Cart cart)
        {

            if(cart != null) { 
            await _context.Cart.AddAsync(cart);
            await _context.SaveChangesAsync();

            var cartItems = new CartItem()
            {
                CartId = cart.Id,
                ProductListId = cart.CartItem.ProductListId,
                customerId = cart.CartItem.customerId,
                Amount = cart.CartItem.Amount
            };
            await _context.CartItem.AddAsync(cartItems);
            await _context.SaveChangesAsync();

            return Ok("Successful");
            }
            else
            {
                return NotFound("Failed");
            }
        }

    }
}
