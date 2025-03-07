using Microsoft.EntityFrameworkCore;

namespace day1
{
    public class AppDbContext : DbContext
    {
        private readonly Guid _instanceId;
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

            _instanceId = Guid.NewGuid(); // Assign unique ID to each instance
            Console.WriteLine($"AppDbContext Instance Created: {_instanceId}");
        }

        public Guid GetInstanceId()
        {
            return _instanceId;
        }

        public DbSet<Student> tempStudent { get; set; }
    }
}