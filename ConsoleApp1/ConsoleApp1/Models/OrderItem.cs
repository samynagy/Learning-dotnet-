using System.ComponentModel.DataAnnotations.Schema;

namespace EFApp.Models
{
    public class OrderItem
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }

        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}