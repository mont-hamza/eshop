using System.ComponentModel.DataAnnotations;
namespace eshop.Data.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string? CustomerName { get; set; } 
        [EmailAddress]
        public string? CustomerEmail { get; set; }
        public int? CustomerPhone { get; set; }
        [MaxLength(100)]
        public string? CustomerAddress { get; set; } 

        public List<Invoice> ?Invoices { get; set; } 

    }
}
