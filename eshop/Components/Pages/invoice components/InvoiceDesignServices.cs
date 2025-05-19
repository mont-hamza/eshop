using eshop.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace eshop.Components.Pages.invoice_components
{
    public class InvoiceDesignServices
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public Customer? Customer { get; set; }
        public Guid CustomerId { get; set; }

        public List <InvoiceDesignServices> GetInvoices()
        {
            return new List<InvoiceDesignServices>
            {
                new InvoiceDesignServices()
                {
                    Id =Guid.NewGuid(),
                    Customer = Customer,
                    CustomerId = CustomerId,
                },
                new InvoiceDesignServices()
                {
                   Id = Guid.NewGuid(),
                    Customer = Customer,
                    CustomerId = CustomerId,
                }
            };
        }
        public InvoiceDesignServices GetInvoiceById(int id)
        {
            return new InvoiceDesignServices()
            {
               Id = Guid.NewGuid(),
                Customer = Customer,
                CustomerId = CustomerId,
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
