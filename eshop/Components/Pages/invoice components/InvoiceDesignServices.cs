namespace eshop.Components.Pages.invoice_components
{
    public class InvoiceDesignServices
    {
        public Guid InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } 
        public string productName { get; private set; }

        public List <InvoiceDesignServices> GetInvoices()
        {
            return new List<InvoiceDesignServices>
            {
                new InvoiceDesignServices()
                {
                    InvoiceId = InvoiceId,
                    CustomerName = CustomerName,
                    CustomerEmail = "email 1",
                    ProductId = ProductId,
                    ProductName = "product 1",
                },
                new InvoiceDesignServices()
                {
                    InvoiceId = InvoiceId,
                    CustomerName = CustomerName,
                    CustomerEmail = "email 1",
                    ProductId = ProductId,
                    productName = "product 1",
                }
            };
        }
        public InvoiceDesignServices GetInvoiceById(int id)
        {
            return new InvoiceDesignServices()
            {
                InvoiceId = InvoiceId,
                CustomerName = CustomerName,
                CustomerEmail = "email 1",
                ProductId= ProductId,
                ProductName = "product 1",
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
