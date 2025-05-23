
using eshop.Data.Entities;
namespace eshop.Components.Pages.customer_components
{
    public class CustomerDesignServices : ICustomerServices
    {
        public List<Customer> GetCustomer()
        {
            return new List<Customer>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    CustomerName = "name 1",
                    CustomerEmail = "email 1",
                    CustomerPhone = 123456789,
                    CustomerAddress = "address 1",
                    Invoices = new List<Invoice>()
                    {
                        new()
                        {
                            Id = Guid.NewGuid(),
                            CustomerId = Guid.NewGuid(),
                            Customer = new Customer()
                            {
                                Id = Guid.NewGuid(),
                                CustomerName = "name 1",
                                CustomerEmail = "email 1",
                                CustomerAddress = "address 1",
                                CustomerPhone = 123456789,
                            }
                        }
                    }
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    CustomerName = "name 2",
                    CustomerEmail = "email 2",
                    CustomerAddress = "address 1",
                    CustomerPhone = 123456789,
                    Invoices = new List<Invoice>()
                    {
                        new()
                        {
                            Id = Guid.NewGuid(),
                            CustomerId = Guid.NewGuid(),
                            Customer = new Customer()
                            {
                                Id = Guid.NewGuid(),
                                CustomerName = "name 2",
                                CustomerEmail = "email 2",
                                CustomerAddress = "address 1",
                                CustomerPhone = 123456789,
                            }
                        }
                    }
                }
            };
        }
        public Customer GetCustomerById(Guid id)
        {
            return new Customer()
            {
                Id = Guid.NewGuid(),
                CustomerName = "name 1",
                CustomerEmail = "email 1",
                CustomerPhone = 123456789,
                CustomerAddress = "address 1",
                Invoices = new List<Invoice>()
                {
                    new()
                    {
                        Id = Guid.NewGuid(),
                        CustomerId = Guid.NewGuid(),
                        Customer = new Customer()
                        {
                            Id = Guid.NewGuid(),
                            CustomerName = "name 1",
                            CustomerEmail = "email 1",
                            CustomerAddress = "address 1",
                            CustomerPhone = 123456789,
                        }
                    }
                }
            };
        }
        public Customer save(Customer customer)
        {
            return customer;
        }
        public Customer updateCustomer(Customer customer)
        {
            return customer;
        }
        public void Delete(Customer customer) { }
    }
}
