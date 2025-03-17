using day4.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customer { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderProduct> OrderProduct { get; set; }
    public DbSet<Product> Product { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>()
            .HasKey(c => c.CustomerId);

        modelBuilder.Entity<Customer>()
            .Property(c => c.CustomerId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Customer>()
            .Property(c => c.Name)
            .IsRequired();

        modelBuilder.Entity<Customer>()
            .Property(c => c.Email)
            .IsRequired();

        modelBuilder.Entity<Customer>()
            .HasIndex(c => c.Email)
            .IsUnique();

        modelBuilder.Entity<Order>()
            .HasKey(o => o.OrderId);

        modelBuilder.Entity<Order>()
            .Property(o => o.OrderId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Order>()
            .HasOne(o => o.Customer)   
            .WithMany(o => o.Orders)  
            .HasForeignKey(c => c.CustomerId);

        modelBuilder.Entity<Product>()
            .HasKey(p => p.ProductId);

        modelBuilder.Entity<Product>()
            .Property(p => p.ProductId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .IsRequired();

        modelBuilder.Entity<Product>()
            .Property(p => p.Stock)
            .IsRequired();

        modelBuilder.Entity<OrderProduct>()
            .HasKey(c => c.OrderProductId);

        modelBuilder.Entity<OrderProduct>()
            .Property(c => c.OrderProductId)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<OrderProduct>()
            .HasOne(o => o.Order)
            .WithMany(p => p.orderProduct)
            .HasForeignKey(o => o.OrderId);

        modelBuilder.Entity<OrderProduct>()
            .HasOne(p => p.Product)
            .WithMany(p => p.orderProduct)
            .HasForeignKey(p => p.ProductId);

        modelBuilder.Entity<OrderProduct>()
            .Property(c => c.Quantity)
            .IsRequired();

        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerId = 1, Name = "John Doe", Email = "john@example.com", CreatedDate = new DateTime(2023, 1, 10) },
            new Customer { CustomerId = 2, Name = "Jane Smith", Email = "jane@example.com", CreatedDate = new DateTime(2023, 3, 15) },
            new Customer { CustomerId = 3, Name = "Alice Brown", Email = "alice@example.com", CreatedDate = new DateTime(2023, 5, 20) },
            new Customer { CustomerId = 4, Name = "Bob White", Email = "bob@example.com", CreatedDate = new DateTime(2023, 7, 25) },
            new Customer { CustomerId = 5, Name = "Charlie Green", Email = "charlie@example.com", CreatedDate = new DateTime(2023, 9, 30) }
        );

        modelBuilder.Entity<Order>().HasData(
            new Order { OrderId = 1, CustomerId = 1, OrderDate = new DateTime(2025, 3, 10, 14, 30, 0), IsDeleted = false },
            new Order { OrderId = 2, CustomerId = 2, OrderDate = new DateTime(2024, 2, 15, 10, 45, 0), IsDeleted = false },
            new Order { OrderId = 3, CustomerId = 3, OrderDate = new DateTime(2024, 3, 20, 16, 0, 0), IsDeleted = true },
            new Order { OrderId = 4, CustomerId = 4, OrderDate = new DateTime(2025, 3, 25, 9, 15, 0), IsDeleted = false },
            new Order { OrderId = 5, CustomerId = 5, OrderDate = new DateTime(2025, 3, 30, 13, 50, 0), IsDeleted = false },
            new Order { OrderId = 6, CustomerId = 1, OrderDate = new DateTime(2024, 6, 5, 11, 20, 0), IsDeleted = false },
            new Order { OrderId = 7, CustomerId = 2, OrderDate = new DateTime(2024, 7, 10, 17, 10, 0), IsDeleted = false }
        );

        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Name = "Laptop", Price = 1000, Stock = 25 },
            new Product { ProductId = 2, Name = "Phone", Price = 500, Stock = 20 },
            new Product { ProductId = 3, Name = "Tablet", Price = 300, Stock = 15 },
            new Product { ProductId = 4, Name = "Monitor", Price = 200, Stock = 5 },
            new Product { ProductId = 5, Name = "Keyboard", Price = 50, Stock = 25 },
            new Product { ProductId = 6, Name = "Mouse", Price = 30, Stock = 30 },
            new Product { ProductId = 7, Name = "Headphones", Price = 80, Stock = 10 }
        );

        modelBuilder.Entity<OrderProduct>().HasData(
            new OrderProduct { OrderProductId = 1, OrderId = 1, ProductId = 1, Quantity = 1 },
            new OrderProduct { OrderProductId = 2, OrderId = 1, ProductId = 3, Quantity = 2 },
            new OrderProduct { OrderProductId = 3, OrderId = 2, ProductId = 2, Quantity = 1 },
            new OrderProduct { OrderProductId = 4, OrderId = 2, ProductId = 5, Quantity = 3 },
            new OrderProduct { OrderProductId = 5, OrderId = 3, ProductId = 4, Quantity = 1 },
            new OrderProduct { OrderProductId = 6, OrderId = 3, ProductId = 7, Quantity = 1 },
            new OrderProduct { OrderProductId = 7, OrderId = 4, ProductId = 6, Quantity = 2 },
            new OrderProduct { OrderProductId = 8, OrderId = 4, ProductId = 1, Quantity = 1 },
            new OrderProduct { OrderProductId = 9, OrderId = 5, ProductId = 3, Quantity = 1 },
            new OrderProduct { OrderProductId = 10, OrderId = 5, ProductId = 2, Quantity = 2 },
            new OrderProduct { OrderProductId = 11, OrderId = 6, ProductId = 7, Quantity = 1 },
            new OrderProduct { OrderProductId = 12, OrderId = 6, ProductId = 5, Quantity = 1 },
            new OrderProduct { OrderProductId = 13, OrderId = 7, ProductId = 4, Quantity = 1 },
            new OrderProduct { OrderProductId = 14, OrderId = 7, ProductId = 6, Quantity = 2 },
            new OrderProduct { OrderProductId = 15, OrderId = 7, ProductId = 1, Quantity = 1 }
        );
    }
}
