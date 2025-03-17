using day5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace day5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] string Department)
        {
            if (Department == null)
            {
                return BadRequest("Invalid customer data.");
            }

            var dept = new Department { DepartmentName = Department };
            _context.Departments.Add(dept);
            _context.SaveChanges();

            return Ok("Customer added successfully");
        }
    }
}
