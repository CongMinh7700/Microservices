using Microsoft.EntityFrameworkCore;

namespace Customer.API.Persistence;

using Entities;

public class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>().HasIndex(p => p.UserName).IsUnique();

        modelBuilder.Entity<Customer>().HasIndex(p => p.EmailAddress).IsUnique();
    }
}
