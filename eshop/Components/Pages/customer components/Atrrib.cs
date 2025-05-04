using eshop.Components.Account.Pages.Manage;

namespace eshop.Components.Pages.customer_components
{
    public class Atrrib
    {
        public int CustomerId = customerId;
        public string CustomerName = customerName;
        public string CustomerEmail = customerEmail;
        public int CustomerPhone = customerPhone;


        public Atrrib(int customerId, string customerName, Email customerEmail, int customerPhone, string customerCity)
        {
            this.CustomerId = customerId;
            this.CustomerName = customerName;
            this.CustomerEmail = customerEmail;
            this.CustomerPhone = customerPhone;
            this.CustomerCity = customerCity;
        }
    }
}
