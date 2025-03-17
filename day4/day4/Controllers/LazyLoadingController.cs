using day4.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LazyLoadingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LazyLoadingController(AppDbContext context) => _context = context;

        [HttpGet("first")]
        public IActionResult First()
        {
            var customers = _context.Customer.ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer: {customer.Name}");

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"  Order ID: {order.OrderId}, Date: {order.OrderDate}");
                }
            }

            return Ok();
        }

        [HttpGet("second")]
        public IActionResult Second()
        {
            var customers = _context.Customer.ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer: {customer.Name}");

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"  Order ID: {order.OrderId}, Date: {order.OrderDate}");
                }
            }

            var data = customers.Select(c => new CustomerDTO
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                Email = c.Email,
                CreatedDate = c.CreatedDate,
                Orders = c.Orders.Select(o => new OrderDTO
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    OrderProducts = o.orderProduct.Select(op => new OrderProductDTO
                    {
                        OrderProductId = op.OrderProductId,
                        Quantity = op.Quantity,
                        Product = new ProductDTO
                        {
                            ProductId = op.Product.ProductId,
                            Name = op.Product.Name,
                            Price = op.Product.Price,
                            Stock = op.Product.Stock
                        }
                    }).ToList()
                }).ToList()
            }).ToList();

            return Ok(data);
        }

        [HttpGet("third")]
        public IActionResult Third()
        {
            var customers = _context.Customer.ToList(); 

            var filteredCustomers = customers
                .Where(c => c.Orders.Any(o => o.orderProduct.Sum(op => op.Product.Price * op.Quantity) > 500))
                .Select(c => new CustomerDTO
                {
                    CustomerId = c.CustomerId,
                    Name = c.Name,
                    Email = c.Email,
                    CreatedDate = c.CreatedDate,
                    Orders = c.Orders
                        .Where(o => o.orderProduct.Sum(op => op.Product.Price * op.Quantity) > 500) // Filter high-value orders
                        .Select(o => new OrderDTO
                        {
                            OrderId = o.OrderId,
                            OrderDate = o.OrderDate,
                            TotalAmount = o.orderProduct.Sum(op => op.Product.Price * op.Quantity),
                            OrderProducts = o.orderProduct.Select(op => new OrderProductDTO
                            {
                                OrderProductId = op.OrderProductId,
                                Quantity = op.Quantity,
                                Product = new ProductDTO
                                {
                                    ProductId = op.Product.ProductId,
                                    Name = op.Product.Name,
                                    Price = op.Product.Price,
                                    Stock = op.Product.Stock
                                }
                            }).ToList()
                        }).ToList()
                }).ToList();

            return Ok(filteredCustomers);
        }
    }
}
