using eshop.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eshop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Invoice> Invoices { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the primary key for Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(c => c.Id);
                entity.Property(c => c.CustomerName).HasMaxLength(50);
                entity.Property(c => c.CustomerEmail).HasMaxLength(100).IsRequired();
                entity.Property(c => c.CustomerPhone).IsRequired(false);
                entity.Property(c => c.CustomerAddress).HasMaxLength(200);
                entity.HasMany(c => c.Invoices)
                      .WithOne(i => i.Customer)
                      .HasForeignKey(i => i.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            // Configure the primary key for Invoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoices");
                entity.HasKey(i => i.Id);
                entity.Property(i => i.CustomerId).IsRequired();
                entity.HasOne(i => i.Customer)
                      .WithMany(c => c.Invoices)
                      .HasForeignKey(i => i.CustomerId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    new Customer
                    {
                        Id = Guid.NewGuid(),
                        CustomerName = "Alice Smith",
                        CustomerEmail = "alice@example.com",
                        CustomerPhone = 1234567890,
                        CustomerAddress = "123 Main St"
                    },
                    new Customer
                    {
                        Id = Guid.NewGuid(),
                        CustomerName = "Bob Johnson",
                        CustomerEmail = "bob@example.com",
                        CustomerPhone = 123443210,
                        CustomerAddress = "456 Elm St"
                    }
                );
                await context.SaveChangesAsync();
            }
        }
    }
}
