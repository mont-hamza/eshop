using eshop.Components.Pages.customer_components;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace eshop.Components.Pages.invoice_components
{
    public class Invoice
    {
        public Invoice() { }
        public Invoice(int id)
        {
            int InvoiceId = id;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
    }
}
