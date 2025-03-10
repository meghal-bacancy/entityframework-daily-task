using day2.DTOs;
using day2.Models;
using Microsoft.AspNetCore.Mvc;

namespace day2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddCustomer([FromBody] CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                return BadRequest("Invalid customer data.");
            }

            var customer = new Customer { Name = customerDTO.Name, isActive = true };
            _context.Customer.Add(customer);
            _context.SaveChanges();

            return Ok("Customer added successfully");
        }

        [HttpGet]
        public IActionResult GetCustomer([FromQuery] int? customerId)
        {
            if (customerId.HasValue)
            {
                var customer = _context.Customer.Where(c => (c.CustomerID == customerId.Value && c.isActive == true))
                    .Select(c => new
                    {
                        CustomerID = c.CustomerID,
                        Name = c.Name
                    });
                return Ok(customer);
            }

            var customers = _context.Customer.Where(c => c.isActive == true).Select(c => new
            {
                CustomerId = c.CustomerID,
                Name = c.Name
            }).ToList();

            return Ok(customers);
        }

        [HttpDelete]
        public IActionResult DeleteCustomer([FromQuery] int customerId)
        {
            if (customerId <= 0)
            {
                return BadRequest("Invalid customer ID.");
            }

            var customer = _context.Customer.FirstOrDefault(c => c.CustomerID == customerId && c.isActive);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            customer.isActive = false;
            _context.SaveChanges();

            return Ok($"Customer with ID {customerId} deleted successfully.");
        }

        [HttpPut]
        public IActionResult UpdateName([FromQuery] UpdateCustomerDTO updateCustomerDTO)
        {
            if (updateCustomerDTO.CustomerID <= 0)
            {
                return BadRequest("Invalid customer ID.");
            }

            var customer = _context.Customer.FirstOrDefault(c => c.CustomerID == updateCustomerDTO.CustomerID && c.isActive);
            if (customer == null)
            {
                return NotFound("Customer not found.");
            }

            customer.Name = updateCustomerDTO.Name;
            _context.SaveChanges();

            return Ok($"Customer with ID {updateCustomerDTO.CustomerID} updated successfully.");
        }
    }
}
