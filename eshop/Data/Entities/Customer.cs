using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eshop.Data.Entities
{
    public class Customer
    {
        [MaxLength(10)]
        [Key]
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public int CustomerPhone { get; set; }
        public string CustomerAddress { get; set; } = string.Empty;
        public Guid InvoiceId { get; set; }

    }
}
