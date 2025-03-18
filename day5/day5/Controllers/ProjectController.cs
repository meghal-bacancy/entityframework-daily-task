using day5.DTOs;
using day5.Models;
using Microsoft.AspNetCore.Mvc;

namespace day5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjectController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Post(ProjectDTO ProjectDTO)
        {
            if (ProjectDTO == null)
            {
                return BadRequest("Invalid Employee data.");
            }

            var project = new Project
            {
                ProjectName = ProjectDTO.ProjectName,
                StartDate = ProjectDTO.StartDate
            };


            _context.Projects.Add(project);
            _context.SaveChanges();
            return Ok("Project added successfully");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var project = _context.Projects
                .Where(p => p.ProjectId == id)
                .Select(p => new ProjectWithEmployeesDTO
                {
                    ProjectName = p.ProjectName,
                    StartDate = p.StartDate,
                    Employees = p.EmployeeProject
                        .Select(ep => new EmployeeDTO
                        {
                            EmployeeId = ep.Employee.EmployeeId,
                            Name = ep.Employee.Name,
                            Email = ep.Employee.Email,
                            DepartmentId = ep.Employee.DepartmentId
                        }).ToList()
                })
                .FirstOrDefault();

            if (project == null)
                return NotFound();

            return Ok(project);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, ProjectDTO projectDTO)
        {
            if (id == null || projectDTO == null)
            {
                return BadRequest("Invalid project data.");
            }

            var project = _context.Projects.FirstOrDefault(e => e.ProjectId == id);

            if (project == null)
            {
                return NotFound("Employee not found.");
            }

            if (!string.IsNullOrEmpty(projectDTO.ProjectName))
            {
                project.ProjectName = projectDTO.ProjectName;
            }

            if (default(DateTime) != projectDTO.StartDate)
            {
                project.StartDate = project.StartDate;
            }

            _context.SaveChanges();

            return Ok("Project updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return BadRequest("Invalid emp data.");
            }

            var project = _context.Projects.Find(id);

            if (project == null)
            {
                return NotFound();
            }

            _context.Projects.Remove(project);
            _context.SaveChanges();

            return Ok("Project Removed");
        }
    }
}
