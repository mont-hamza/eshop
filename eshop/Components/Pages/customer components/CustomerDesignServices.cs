namespace eshop.Components.Pages.customer_components
{
    public class CustomerDesignServices
    {
        public Guid CustomerId { get;  set; }
        public string CustomerName { get;  set; }
        public string CustomerEmail { get;  set; }
        public int CustomerPhone { get;  set; }
        public string CustomerAddress { get;  set; }

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
                },
                new CustomerDesignServices()
                {
                    CustomerId = Guid.NewGuid(),
                    CustomerName = "name 2",
                    CustomerEmail = "email 2",
                    CustomerAddress = "address 1",
                    CustomerPhone = 123456789,
                }
            };
        }
        public Customer updateCustomer( Customer customer) 
        { return customer; }
        public void Delete(Customer customer)
        {

        }
    }
}
