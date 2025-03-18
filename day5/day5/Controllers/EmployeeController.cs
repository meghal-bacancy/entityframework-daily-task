using day5.DTOs;
using day5.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(EmployeeDTO EmployeeDTO)
        {
            if (EmployeeDTO == null)
            {
                return BadRequest("Invalid Employee data.");
            }

            var employee = new Employee
            {
                Name = EmployeeDTO.Name,
                Email = EmployeeDTO.Email,
                DepartmentId = EmployeeDTO.DepartmentId,
            };


            _context.Employees.Add(employee);
            _context.SaveChanges();
            return Ok("Employee added successfully");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == null)
            {
                return BadRequest("Department customer data.");
            }

            var emp = _context.Employees.FirstOrDefault(d => d.EmployeeId == id);


            if (emp == null)
            {
                return NotFound($"No employee found for department with ID {id}.");
            }

            var employeeDTO = new EmployeeDTO
            {
                EmployeeId = emp.EmployeeId,
                Name = emp.Name,
                Email = emp.Email,
                DepartmentId = emp.DepartmentId
            };
            return Ok(employeeDTO);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, EmployeeDTO employeeDTO)
        {
            if (id == null || employeeDTO == null)
            {
                return BadRequest("Invalid Department data.");
            }

            var emp = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);

            if (emp == null)
            {
                return NotFound("Employee not found.");
            }

            if (!string.IsNullOrEmpty(employeeDTO.Name))
            {
                emp.Name = employeeDTO.Name;
            }

            if (!string.IsNullOrEmpty(employeeDTO.Email))
            {
                emp.Email = employeeDTO.Email;
            }

            _context.SaveChanges();

            return Ok("Employee updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Invalid emp data.");
            }

            var emp = _context.Employees.Find(id);

            if (emp == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(emp);
            _context.SaveChanges();

            return Ok("Employee Removed");
        }
    }
}
