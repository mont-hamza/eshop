using eshop.Data.Entities;
namespace eshop.Components.Pages.Product_components
{
    public interface IProductServices
    {
        Task<List<Product>> GetProducts();
        Task<Product?> GetProductById(Guid id);
        Task<Product> SaveProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(Product product);
    }
}