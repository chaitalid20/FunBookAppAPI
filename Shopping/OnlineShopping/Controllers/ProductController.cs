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
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext datacontext)
        {
            this._context = datacontext;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IList<ProductList>>> GetAllProducts()
        {
            var product = await _context.ProductList.ToListAsync();
            if (product != null) { 
            return Ok(product);
            }
            else
            {
                return NotFound("Data not foun"+ product);
            }
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        [ActionName("GetOneProduct")]
        public async Task<IActionResult> GetOneProduct(int id)
        {
            var product = await _context.ProductList.FirstOrDefaultAsync(x => x.Id == id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound("Product not Found");
        }

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductList product)
        {
            //product.CreatedOn = DateTime.UtcNow;
            await _context.ProductList.AddAsync(product);
            await _context.SaveChangesAsync();
            return Ok(product);
            //return CreatedAtAction(nameof(GetOneTask), new { id = product.Id }, product);

        }

        // PUT: api/Product/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductList products)
        //{
        //    var existingProd = await _context.ProductList.FirstOrDefaultAsync(x => x.Id == id);
        //    if (existingProd != null)
        //    {
        //        existingProd.ProductName = products.ProductName;
        //        existingProd.ProductTypeId = products.ProductTypeId;
        //        existingProd.Price = products.Price;
        //        existingProd.Description = products.Description;
        //        await _context.SaveChangesAsync();
        //        return Ok(existingProd);
        //    }
        //    return NotFound("Task not Found");

        //}

    }
}
