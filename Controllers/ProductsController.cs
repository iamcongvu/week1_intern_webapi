using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week1.Data;
using Week1.Data.Dtos;

namespace Week1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var data = await _context.Products.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByIdAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task CreateAsync([FromBody] ProductDto productDto)
        {
            var productEntity = new Product();
            productEntity.Name = productDto.Name;
            productEntity.Price = productDto.Price;

            _context.Products.Add(productEntity);
            await _context.SaveChangesAsync();
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> PutAsync(int productId, [FromBody] ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = productDto.Name;
            product.Price = productDto.Price;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPatch("price/{productId}/{newPrice}")]
        public async Task<IActionResult> UpdatePriceAsync(int productId, double newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            product.Price = newPrice;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}