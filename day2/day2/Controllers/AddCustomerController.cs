using day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddCustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AddCustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddCustomer(string name)
        {
            var customer = new Customer { Name = name };
            _context.Customer.Add(customer);
            _context.SaveChanges();

            return Ok("Customer added successfully");
        }
    }
}
