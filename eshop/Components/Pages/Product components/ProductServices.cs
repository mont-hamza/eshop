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
            return await _DbContext.Products.ToListAsync();
        }
        public async Task<Product?> GetProductById(Guid id)
        {
            var _DbContext = _contextFactory.CreateDbContext();
            return await _DbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task AddProduct(Product product)
        {
            var _DbContext = _contextFactory?.CreateDbContext();
            if (_DbContext == null)
            {
                throw new Exception("Database context is not available");
            }
            _DbContext.Products.Add(product);
            await _DbContext.SaveChangesAsync();
        }
        public async Task UpdateProduct(Product product)
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
            existingProduct.Description = product.Description;
            existingProduct.Category = product.Category;
            existingProduct.Price = product.Price;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.StockQuantity = product.StockQuantity;
            await _DbContext.SaveChangesAsync();
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
    }
}