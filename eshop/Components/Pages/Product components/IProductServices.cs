using eshop.Data.Entities;

public interface IProductServices
{
    Task<List<Product>> GetProducts();
    Task<Product?> GetProductById(Guid id);
    Task AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(Product product);
}