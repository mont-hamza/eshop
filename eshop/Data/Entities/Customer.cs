namespace eshop.Data.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public int CustomerPhone { get; set; }
        public string CustomerAddress { get; set; } = string.Empty;

    }
}
