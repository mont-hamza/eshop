using System.ComponentModel.DataAnnotations;

namespace eshop.Data.Entities
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        [MaxLength(500)]
        public string? Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int? StockQuantity { get; set; }
    }
}
