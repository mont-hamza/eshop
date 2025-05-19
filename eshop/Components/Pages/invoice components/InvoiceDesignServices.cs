using eshop.Data.Entities;

namespace eshop.Components.Pages.invoice_components
{
    public class InvoiceDesignServices
    {
        public List <Invoice> GetInvoices()
        {
            return new List<Invoice>
            {
                new()
                {
                    Id = Guid.NewGuid(),
                    Customer = new Customer()
                    {
                        Id = Guid.NewGuid(),
                        CustomerName = "name 1",
                        CustomerEmail = "email 1",
                        CustomerPhone = 123456789,
                        CustomerAddress = "address 1",
                    },
                    CustomerId = Guid.NewGuid(),
                },
                new()
                {
                    Id = Guid.NewGuid(),
                    Customer = new Customer()
                    {
                        Id = Guid.NewGuid(),
                        CustomerName = "name 2",
                        CustomerEmail = "email 2",
                        CustomerPhone = 123456789,
                        CustomerAddress = "address 1",
                    },
                    CustomerId = Guid.NewGuid(),
                }

            };
        }
        public Invoice GetInvoicebyId(Guid id)
        {
            return new Invoice()
            {
                Id = Guid.NewGuid(),
                CustomerId = Guid.NewGuid(),
                Customer = new Customer()
                {
                    Id = Guid.NewGuid(),
                    CustomerName = "name 1",
                    CustomerEmail = "email 1",
                    CustomerPhone = 123456789,
                    CustomerAddress = "address 1",
                }
            };
        }
        
        public Invoice Save(Invoice invoice)
        {
            return invoice;
        }
        public Invoice UpdateInvoice(Invoice invoice)
        {
            return invoice;
        }
        public void Delete(Invoice invoice)
        {
            // Logic to delete the invoice
        }   
    }
}
