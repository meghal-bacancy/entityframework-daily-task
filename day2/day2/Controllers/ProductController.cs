using day2.DTOs;
using day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context) => _context = context;

        [HttpPost]
        public IActionResult AddProduct([FromBody] ProductDTO productDTO)
        {
            if (productDTO == null)
            {
                return BadRequest("Invalid product data.");
            }

            var product = new Product
            {
                Name = productDTO.Name,
                Price = productDTO.Price
            };
            _context.Product.Add(product);
            _context.SaveChanges();

            return Ok("Product added successfully");
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] int? productId)
        {
            if (productId.HasValue)
            {
                var product = _context.Product.Where(p => p.ProductId == productId.Value)
                    .Select(p => new
                    {
                        ProductId = p.ProductId,
                        Name = p.Name
                    });
                return Ok(product);
            }
            var products = _context.Product.Select(p => new
            {
                ProductId = p.ProductId,
                Name = p.Name
            }).ToList();

            return Ok(products);
        }

        [HttpDelete]
        public IActionResult DeleteProduct([FromQuery] int productId)
        {
            if (productId <= 0)
            {
                return BadRequest("Invalid product ID.");
            }

            var product = _context.Product.FirstOrDefault(c => c.ProductId == productId);
            if (product == null)
            {
                return NotFound("Customer not found.");
            }

            _context.Product.Remove(product);
            _context.SaveChanges();

            return Ok($"Product with ID {productId} deleted successfully.");
        }

        [HttpPut]
        public IActionResult UpdatePrice([FromQuery] UpdateProductDTO updateProductDTO)
        {
            if (updateProductDTO.ProductID <= 0)
            {
                return BadRequest("Invalid product ID.");
            }

            var product = _context.Product.FirstOrDefault(p => p.ProductId == updateProductDTO.ProductID);
            if (product == null)
            {
                return NotFound("product not found.");
            }

            product.Price = updateProductDTO.Price;
            _context.SaveChanges();

            return Ok($"Customer with ID {updateProductDTO.ProductID} updated successfully.");
        }
    }
}