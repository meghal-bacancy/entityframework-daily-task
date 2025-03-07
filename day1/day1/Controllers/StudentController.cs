using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace day1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
            Console.WriteLine($"StudentController - DbContext Instance ID: {_context.GetInstanceId()}");
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            Console.WriteLine($"Handling GET request - DbContext Instance ID: {_context.GetInstanceId()}");
            var students = await _context.tempStudent.ToListAsync();
            return Ok(students);
        }
    }
}