using System.ComponentModel.DataAnnotations;

namespace eshop.Data.Entities
{
    public class Invoice
    {
        
        public Guid Id { get; set; }
        [MaxLength(50)]
        public Guid CustomerId { get; set; }
        public Customer ?Customer { get; set; }
    }
}
