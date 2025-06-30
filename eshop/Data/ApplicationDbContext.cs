using eshop.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MudBlazor;

namespace eshop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Customer> Customers { get; set; } = default!;
        public DbSet<Invoice> Invoices { get; set; } = default!;
        public DbSet<Product> Products { get; set; } = default!;
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
            // Configure the primary key for Product    
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(500);
                entity.Property(p => p.Category).IsRequired().HasMaxLength(50);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.ImageUrl).IsRequired();
                entity.Property(p => p.StockQuantity).IsRequired(false);
            });
        }
    }
    
}
