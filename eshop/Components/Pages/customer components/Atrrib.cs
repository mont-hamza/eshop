using eshop.Components.Account.Pages.Manage;

namespace eshop.Components.Pages.customer_components
{
    public class Atrrib
    {
        public int CustomerId;
        public string CustomerName;
        public Email CustomerEmail;
        public int CustomerPhone;
        public string CustomerCity;

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
