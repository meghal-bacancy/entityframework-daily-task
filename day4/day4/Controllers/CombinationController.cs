using day4.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombinationController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CombinationController(AppDbContext context) => _context = context;

        [HttpGet("first")]
        public IActionResult First()
        {
            var customers = _context.Customer
                            .Include(c => c.Orders) 
                            .ToList();

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer: {customer.Name}");

                foreach (var order in customer.Orders)
                {
                    Console.WriteLine($"  Order ID: {order.OrderId}, Date: {order.OrderDate}");

                    if (order.orderProduct != null)
                    {
                        foreach (var orderProduct in order.orderProduct)
                        {
                            Console.WriteLine($"    OrderProduct ID: {orderProduct.OrderProductId}, Product: {orderProduct.Product.Name}, Quantity: {orderProduct.Quantity}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("    No OrderProducts for this Order.");
                    }
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

        [HttpGet("second")]
        public IActionResult second()
        {
            var orders = _context.Order
                            .Include(o => o.Customer)  
                            .ToList();

            foreach (var order in orders)
            {
                if (order.orderProduct != null && order.orderProduct.Any(op => op.Quantity > 5))
                {
                    _context.Entry(order).Collection(o => o.orderProduct)
                            .Query()  
                            .Where(op => op.Quantity > 5)
                            .Load();
                }
            }

            var orderDTOs = orders.Select(o => new OrderDTO
            {
                OrderId = o.OrderId,
                OrderDate = o.OrderDate,
                Customer = new CustomerDTO
                {
                    CustomerId = o.Customer.CustomerId,
                    Name = o.Customer.Name
                },
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
            }).ToList();

            return Ok(orderDTOs);
        }

        [HttpGet("third")]
        public async Task<IActionResult> third()
        {
            var customers = await _context.Customer.Include(c => c.Orders).ToListAsync();
            var vipCustomers = customers.Where(c => c.IsVIP).ToList();

            var customerDtos = new List<CustomerDTO>();

            foreach (var customer in vipCustomers)
            {
                foreach (var order in customer.Orders)
                {
                    await _context.Entry(order)
                        .Collection(o => o.orderProduct)
                        .LoadAsync();

                    foreach (var orderProduct in order.orderProduct)
                    {
                        await _context.Entry(orderProduct)
                            .Reference(op => op.Product)
                            .LoadAsync();
                    }
                }

                var customerDto = new CustomerDTO
                {
                    CustomerId = customer.CustomerId,
                    Name = customer.Name,
                    IsVIP = customer.IsVIP,
                    Orders = customer.Orders.Select(o => new OrderDTO
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate,
                        Customer = new CustomerDTO
                        {
                            CustomerId = customer.CustomerId,
                            Name = customer.Name,
                            IsVIP = customer.IsVIP
                        },
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
                };

                customerDtos.Add(customerDto);
            }

            return Ok(customerDtos);
        }
    }
}