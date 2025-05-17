
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using eshop.Data.Entities;
namespace eshop.Components.Pages.customer_components
{
    public class CustomerDesignServices
    {

        [MaxLength(10)]
        [Key]
        public Guid CustomerId { get;  set; }
        [AllowNull]
        public string CustomerName { get;  set; }
        [AllowNull]
        public string CustomerEmail { get;  set; }
        public int CustomerPhone { get;  set; }
        [AllowNull]
        public string CustomerAddress { get;  set; }
        public Guid InvoiceId { get; set; } = Guid.NewGuid();

        public List<CustomerDesignServices> GetCustomer()
        {
            return new List<CustomerDesignServices>
            {
                new CustomerDesignServices()
                {
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "name 1",
                    CustomerEmail = "email 1",
                    CustomerPhone = 123456789,
                    CustomerAddress = "address 1",
                    InvoiceId = Guid.NewGuid(),
                },
                new CustomerDesignServices()
                {
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "name 2",
                    CustomerEmail = "email 2",
                    CustomerAddress = "address 1",
                    CustomerPhone = 123456789,
                    InvoiceId = Guid.NewGuid(),
                }
            };
        }

        public CustomerDesignServices GetCustomerById(Guid id)
        {
            return new CustomerDesignServices()
            {
                CustomerId = Guid.NewGuid(),
                CustomerName = "name 1",
                CustomerEmail = "email 1",
                CustomerPhone = 123456789,
                CustomerAddress = "address 1",
                InvoiceId = Guid.NewGuid(),
            };
        }
        public Customer save (Customer customer)
        {
            return customer;
        }
        public Customer updateCustomer( Customer customer) 
        { 
            return customer;
        }
        public void Delete(Customer customer) { }
    }
}
