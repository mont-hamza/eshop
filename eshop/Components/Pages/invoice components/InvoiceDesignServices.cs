namespace eshop.Components.Pages.invoice_components
{
    public class InvoiceDesignServices
    {
        public int InvoiceId { get; private set; }
        public int CustomerId { get; private set; }

        public List <InvoiceDesignServices> GetInvoices()
        {
            return new List<InvoiceDesignServices>
            {
                new InvoiceDesignServices()
                {
                    InvoiceId = 1,
                    CustomerId = 1,
                },
                new InvoiceDesignServices()
                {
                    InvoiceId = 2,
                    CustomerId = 2,
                }
            };
        }
        public InvoiceDesignServices GetInvoiceById(int id)
        {
            return new InvoiceDesignServices()
            {
                InvoiceId = 1,
                CustomerId = 1,
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
