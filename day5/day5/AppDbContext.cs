using day5.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeProject> EmployeeProjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
            .HasKey(d => d.DepartmentId);

        modelBuilder.Entity<Department>()
            .Property(d => d.DepartmentId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Employee>()
            .HasKey(e => e.EmployeeId);

        modelBuilder.Entity<Employee>()
            .Property(e => e.EmployeeId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Project>()
            .HasKey(p => p.ProjectId);

        modelBuilder.Entity<Project>()
            .Property(p => p.ProjectId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<EmployeeProject>()
            .HasKey(ep => new { ep.EmployeeId, ep.ProjectId });

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department) 
            .WithMany(d => d.Employee)   
            .HasForeignKey(e => e.DepartmentId)  
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EmployeeProject>()
            .HasOne(e => e.Employee)  
            .WithMany(ep => ep.EmployeeProject)   
            .HasForeignKey(e => e.EmployeeId) 
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<EmployeeProject>()
            .HasOne(e => e.Project)
            .WithMany(ep => ep.EmployeeProject) 
            .HasForeignKey(e => e.ProjectId)  
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentName = "IT" },
            new Department { DepartmentName = "HR" },
            new Department { DepartmentName = "Finance" }
        );

        modelBuilder.Entity<Employee>().HasData(
            new Employee { Name = "John Doe", Email = "john@example.com", DepartmentId = 1 },
            new Employee {  Name = "Jane Smith", Email = "jane@example.com", DepartmentId = 2 },
            new Employee { Name = "Alice Brown", Email = "alice@example.com", DepartmentId = 3 },
            new Employee { Name = "Bob Johnson", Email = "bob@example.com", DepartmentId = 1 },
            new Employee { Name = "Charlie White", Email = "charlie@example.com", DepartmentId = 2 },
            new Employee { Name = "David Black", Email = "david@example.com", DepartmentId = 3 },
            new Employee { Name = "Emma Wilson", Email = "emma@example.com", DepartmentId = 1 },
            new Employee { Name = "Frank Adams", Email = "frank@example.com", DepartmentId = 2 },
            new Employee { Name = "Grace Harris", Email = "grace@example.com", DepartmentId = 3 },
            new Employee { Name = "Hank Miller", Email = "hank@example.com", DepartmentId = 1 },
            new Employee { Name = "Ivy Clark", Email = "ivy@example.com", DepartmentId = 2 },
            new Employee { Name = "Jack Lewis", Email = "jack@example.com", DepartmentId = 3 },
            new Employee { Name = "Kate Scott", Email = "kate@example.com", DepartmentId = 1 }
        );

        modelBuilder.Entity<Project>().HasData(
            new Project { ProjectName = "Alpha", StartDate = new DateTime(2024, 3, 1, 9, 0, 0) },
            new Project { ProjectName = "Beta", StartDate = new DateTime(2024, 3, 2, 10, 0, 0) },
            new Project { ProjectName = "Gamma", StartDate = new DateTime(2024, 3, 3, 11, 0, 0) },
            new Project { ProjectName = "Delta", StartDate = new DateTime(2024, 3, 4, 12, 0, 0) },
            new Project { ProjectName = "Epsilon", StartDate = new DateTime(2024, 3, 5, 13, 0, 0) },
            new Project { ProjectName = "Zeta", StartDate = new DateTime(2024, 3, 6, 14, 0, 0) },
            new Project { ProjectName = "Eta", StartDate = new DateTime(2024, 3, 7, 15, 0, 0) },
            new Project { ProjectName = "Theta", StartDate = new DateTime(2024, 3, 8, 16, 0, 0) },
            new Project { ProjectName = "Iota", StartDate = new DateTime(2024, 3, 9, 17, 0, 0) },
            new Project { ProjectName = "Kappa", StartDate = new DateTime(2024, 3, 10, 18, 0, 0) }
        );

        modelBuilder.Entity<EmployeeProject>().HasData(
            new EmployeeProject { EmployeeId = 1, ProjectId = 1, Role = "Developer" },
            new EmployeeProject { EmployeeId = 4, ProjectId = 1, Role = "Developer" },
            new EmployeeProject { EmployeeId = 7, ProjectId = 1, Role = "Developer" },
            new EmployeeProject { EmployeeId = 2, ProjectId = 1, Role = "Manager" },
            new EmployeeProject { EmployeeId = 3, ProjectId = 2, Role = "Tester" },
            new EmployeeProject { EmployeeId = 4, ProjectId = 2, Role = "Developer" },
            new EmployeeProject { EmployeeId = 7, ProjectId = 2, Role = "Developer" },
            new EmployeeProject { EmployeeId = 5, ProjectId = 3, Role = "Manager" },
            new EmployeeProject { EmployeeId = 6, ProjectId = 3, Role = "Tester" },
            new EmployeeProject { EmployeeId = 7, ProjectId = 4, Role = "Developer" },
            new EmployeeProject { EmployeeId = 8, ProjectId = 4, Role = "Manager" },
            new EmployeeProject { EmployeeId = 9, ProjectId = 5, Role = "Tester" },
            new EmployeeProject { EmployeeId = 3, ProjectId = 5, Role = "Tester" },
            new EmployeeProject { EmployeeId = 10, ProjectId = 5, Role = "Developer" }
        );
    }
}