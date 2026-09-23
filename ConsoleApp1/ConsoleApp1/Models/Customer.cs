using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFApp.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set;}

        [Required]
        public string Email { get; set;}

        /// one-to-one with custoemr profile
        public CustomerProfile customerProfile { get; set;}

        /// one-to-many
        
        public ICollection<Order> Orders { get; set; }

    }
}
