using System.ComponentModel.DataAnnotations;

namespace eshop.Data.Entities
{
    public class InvoiceItem
    {
        [Key]
        public int Id { get; set; }
        public Guid InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public Product? Product { get; set; }
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? ImageUrl { get; set; }= null;
        
    }
}