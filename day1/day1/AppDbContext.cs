using day1;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=MEGHAL-F15\\SQLEXPRESS;Database=E_Commerce_System;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}
