using day2.DTOs;
using day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderDTO orderDTO)
        {
            if (orderDTO == null)
            {
                return BadRequest("Invalid product data.");
            }

            var order = new Order { CustomerID = orderDTO.CustomerID };
            _context.Order.Add(order);
            _context.SaveChanges();

            int orderId = order.OrderID;

            foreach(var i in orderDTO.Products)
            {
                if (int.TryParse(i.Key, out int productId))
                {
                    var orderProduct = new OrderProduct { OrderId = orderId, ProductId = productId, Quantity = i.Value };
                    _context.OrderProduct.Add(orderProduct);
                }
                _context.SaveChanges();
            }

            return Ok("Customer added successfully");
        }
    }
}
