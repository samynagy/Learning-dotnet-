using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }

        /// one-to-many 
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        // Many : Many through OrderItem
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}