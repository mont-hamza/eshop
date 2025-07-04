using eshop.Data.Entities;
namespace eshop.Components.Pages.customer_components
{
    public interface ICustomerServices
    {
        Task <List<Customer>> GetCustomer();
        Task <Customer?> GetCustomerById(Guid id);
        Task <Customer> save(Customer customer);
        Task <Customer> updateCustomer(Customer customer);
        Task DeleteAsync(Guid id);
    }
}