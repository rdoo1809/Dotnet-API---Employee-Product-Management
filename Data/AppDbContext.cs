using Microsoft.EntityFrameworkCore;

namespace Assignment1_PROG3340.Data;

public class AppDbContext : DbContext
{
    private readonly IHostEnvironment _env;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Employees { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
         
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (_env.IsDevelopment())
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Dev Alice", Department = "Produce" },
                new Employee { Id = 2, Name = "Dev Gilbert", Department = "Meat" }
            );    
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Dev Product A", Price = 18 },
                new Product { Id = 2, Name = "Dev Product B", Price = 9 }
            );
        }
        else
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Production Alice", Department = "Produce" },
                new Employee { Id = 2, Name = "Production Gilbert", Department = "Meat" }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Sausages", Price = 12 },
                new Product { Id = 2, Name = "Hamburgers", Price = 15 }
            );
        }
    }
}