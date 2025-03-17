using day4.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExplicitLoadingController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ExplicitLoadingController(AppDbContext context) => _context = context;

        [HttpGet("first")]
        public IActionResult first(int customerId)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.CustomerId == customerId);

            if (customer.CreatedDate > DateTime.UtcNow.AddYears(-1))
            {
                _context.Entry(customer).Collection(c => c.Orders).Load();
                var customerDTO = new CustomerDTO
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    Email = customer.Email,
                    CreatedDate = customer.CreatedDate,
                    Orders = customer.Orders.Select(o => new OrderDTO
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate
                    }).ToList()
                };
                return Ok(customerDTO);
            }

            return Ok(null);
        }

        [HttpGet("second")]
        public IActionResult second()
        {
            var orders = _context.Order.ToList();
            foreach (var order in orders)
            {
                _context.Entry(order).Collection(o => o.orderProduct).Load();
                Console.WriteLine($"Order ID: {order.OrderId}, Order Date: {order.OrderDate}");
                foreach (var orderProduct in order.orderProduct)
                {
                    Console.WriteLine($"  OrderProduct ID: {orderProduct.OrderProductId}, Product ID: {orderProduct.ProductId}, Quantity: {orderProduct.Quantity}");
                }
            }

            return Ok();
        }

        [HttpGet("third")]
        public IActionResult third()
        {
            var orders = _context.Order.ToList();
            var products = _context.Product.ToList();
            var productsWithOrders = new List<ProductDTO>();

            foreach (var product in products)
            {
                if (product.Stock < 10)
                {
                    _context.Entry(product).Collection(p => p.orderProduct).Query()
                        .Include(op => op.Order)  
                        .Load();

                    var productDto = new ProductDTO
                    {
                        ProductId = product.ProductId,
                        Name = product.Name,
                        Price = product.Price,
                        Stock = product.Stock
                    };

                    foreach (var orderProduct in product.orderProduct)
                    {
                        productDto.Orders.Add(new OrderDTO
                        {
                            OrderId = orderProduct.Order.OrderId,
                            OrderDate = orderProduct.Order.OrderDate
                        });
                    }

                    productsWithOrders.Add(productDto);
                }
            }
            
            return Ok(productsWithOrders);
        }

        [HttpGet("fourth")]
        public IActionResult fourth()
        {
            var customers = _context.Customer
                                .Include(c => c.Orders)
                                .ToList();

            foreach (var customer in customers)
            {
                foreach (var order in customer.Orders)
                {
                    _context.Entry(order).Collection(o => o.orderProduct).Load();
                }
            }

            var customersWithOrdersAndProducts = customers.Select(c => new CustomerDTO
            {
                CustomerId = c.CustomerId,
                Name = c.Name,
                Email = c.Email,
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
                            Price = op.Product.Price
                        }
                    }).ToList()
                }).ToList()
            }).ToList();

            return Ok(customersWithOrdersAndProducts);
        }
    }
}
