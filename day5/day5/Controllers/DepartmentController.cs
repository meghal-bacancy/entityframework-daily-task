using day5.DTOs;
using day5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return Ok("Department added successfully");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == null)
            {
                return BadRequest("Department customer data.");
            }

            var department = _context.Departments.Include(d => d.Employee).FirstOrDefault(d => d.DepartmentId == id);

            var departmentDto = new DepartmentDTO
            {
                DepartmentId = department.DepartmentId,
                DepartmentName = department.DepartmentName,
                Employees = department.Employee.Select(e => new EmployeeDTO
                {
                    EmployeeId = e.EmployeeId,
                    Name = e.Name
                }).ToList()
            };
            return Ok(departmentDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, DepartmentNameDTO department)
        {
            if (id == null)
            {
                return BadRequest("Invalid Department data.");
            }

            var dept = _context.Departments.Find(id);

            if (dept == null)
            {
                return NotFound();
            }

            dept.DepartmentName = department.DepartmentName;
            _context.SaveChanges();

            return Ok("Name Changed");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Invalid customer data.");
            }

            var dept = _context.Departments.Find(id);

            if (dept == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(dept);
            _context.SaveChanges();

            return Ok("Department Removed");
        }
    }
}
