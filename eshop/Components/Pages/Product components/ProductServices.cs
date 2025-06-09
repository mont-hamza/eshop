
using eshop.Data;
using eshop.Data.Entities;
using Microsoft.EntityFrameworkCore;
namespace eshop.Components.Pages.Product_components
{
    public class ProductServices : IProductServices
    {

        private readonly IDbContextFactory<ApplicationDbContext>? _contextFactory;
        public ProductServices(IDbContextFactory<ApplicationDbContext>? contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Product>> GetProducts()
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
            {
                throw new Exception("Database context is not available");
            }
            return await _DbContext.Products.ToListAsync();
        }
        public async Task<Product?> GetProductById(Guid id)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
            {
                throw new Exception("Database context is not available");
            }
            return await _DbContext.Products.FindAsync(id);
        }
        public async Task<Product> SaveProduct(Product product)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
            {
                throw new Exception("Database context is not available");
            }
            _DbContext.Products.Add(product);
            await _DbContext.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
            {
                throw new Exception("Database context is not available");
            }
            var existingProduct = await _DbContext.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }
            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.ImageUrl = product.ImageUrl;
            await _DbContext.SaveChangesAsync();
            return existingProduct;
        }
        public async Task DeleteProduct(Product product)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
            {
                throw new Exception("Database context is not available");
            }
            var existingProduct = await _DbContext.Products.FindAsync(product.Id);
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }
            _DbContext.Products.Remove(existingProduct);
            await _DbContext.SaveChangesAsync();
        }
        public Task<List<Product>> GetSampleProducts()
        {
            var sampleProducts = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Sample Product 1", Price = 10.99m, Description = "This is a sample product.", ImageUrl = "https://example.com/sample1.jpg" },
                new Product { Id = Guid.NewGuid(), Name = "Sample Product 2", Price = 20.99m, Description = "This is another sample product.", ImageUrl = "https://example.com/sample2.jpg" },
                new Product { Id = Guid.NewGuid(), Name = "Sample Product 3", Price = 30.99m, Description = "This is yet another sample product.", ImageUrl = "https://example.com/sample3.jpg" }
            };
            return Task.FromResult(sampleProducts);
        }
    }
}
