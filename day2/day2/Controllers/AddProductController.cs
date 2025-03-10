using day2.DTOs;
using day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AddProductController(AppDbContext context) => _context = context;

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Invalid product data.");
            }

            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price
            };
            _context.Product.Add(product);
            _context.SaveChanges();

            return Ok("Product added successfully");
        }
    }
}