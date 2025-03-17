using day4.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace day4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EagerLoadingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EagerLoadingController(AppDbContext context) => _context = context;

        [HttpGet("first")]
        public IActionResult first()
        {
            var customers = _context.Customer
                                .Include(c => c.Orders)
                                .ThenInclude(o => o.orderProduct)
                                .ThenInclude(op => op.Product)
                                .ToList()
                .Select(c => new CustomerDTO
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

            return Ok(customers);
        }


        [HttpGet("second")]
        public IActionResult Second()
        {
            var last30DaysOrders = _context.Customer.Include(c => c.Orders.Where(o => o.OrderDate >= DateTime.UtcNow.AddDays(-30) || o.OrderDate >= DateTime.UtcNow.AddDays(+30)))
                                    .ThenInclude(o => o.orderProduct.Where(op => op.Product.Stock > 20))
                                    .ThenInclude(op => op.Product)
                                    .ToList().Select(c => new CustomerDTO
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

            return Ok(last30DaysOrders);
        }

        [HttpGet("third")]
        public IActionResult third()
        {
            var productsWithOrderCount = _context.Product.Include(p => p.orderProduct)
                .Select(p => new
                {
                    ProductName = p.Name,
                    OrderCount = p.orderProduct.Count()
                }).ToList();

            return Ok(productsWithOrderCount);
        }

        [HttpGet("fourth")]
        public IActionResult fourth()
        {
            var lastMonthOrders = _context.Order
                .Where(o => o.OrderDate >= DateTime.UtcNow.AddMonths(-1))
                .Include(o => o.Customer)
                .ToList().Select(o => new OrderDTO
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
                }).ToList();

            return Ok(lastMonthOrders);
        }
    }
}
