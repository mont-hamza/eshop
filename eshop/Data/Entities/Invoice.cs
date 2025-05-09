namespace eshop.Data.Entities
{
    public class Invoice
    {
        public Invoice(int id) 
        {
            InvoiceId = id;
            // Initialize other properties if needed
        }
        public Invoice(string id) 
        {
            if (int.TryParse(id, out int invoiceId))
            {
                InvoiceId = invoiceId;
            }
            else
            {
                InvoiceId = 0; // or handle the error as needed
            }
        }
        public int InvoiceId { get; set; }
    }
}
