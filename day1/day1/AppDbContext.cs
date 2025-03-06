using Microsoft.EntityFrameworkCore;

internal class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<day1.temp> temps { get; set; }
}