namespace eshop.Components.Pages.invoice_components
{
    public class InvoiceDesignServices
    {
        public Guid InvoiceId { get; set; }
        public Guid CustomerId { get; set; }

        public List <InvoiceDesignServices> GetInvoices()
        {
            return new List<InvoiceDesignServices>
            {
                new InvoiceDesignServices()
                {
                    InvoiceId = InvoiceId,
                    CustomerId = CustomerId,
                },
                new InvoiceDesignServices()
                {
                    InvoiceId = InvoiceId,
                    CustomerId = CustomerId,
                }
            };
        }
        public InvoiceDesignServices GetInvoiceById(int id)
        {
            return new InvoiceDesignServices()
            {
                InvoiceId = InvoiceId,
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
