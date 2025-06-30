using eshop.Data;
using eshop.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace eshop.Components.Pages.Product_components
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;

        public ProductServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetProducts() =>
            await _context.Products.ToListAsync();

        public async Task<Product?> GetProductById(Guid id) =>
            await _context.Products.FindAsync(id);

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}