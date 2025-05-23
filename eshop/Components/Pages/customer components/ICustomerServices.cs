using eshop.Data.Entities;

namespace eshop.Components.Pages.customer_components
{
    public interface ICustomerServices
    {
        void Delete(Customer customer);
        List<Customer> GetCustomer();
        Customer GetCustomerById(Guid id);
        Customer save(Customer customer);
        Customer updateCustomer(Customer customer);
    }
}