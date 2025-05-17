namespace eshop.Data.Entities
{
    public class Invoice
    {
        
        public Guid InvoiceId { get; set; }
        public int CustomerName { get; set; }
        public string CustomerEmail { get; set; } = string.Empty;
        public int productId { get; set; }
        public string productName { get; set; } = string.Empty;
    }
}
