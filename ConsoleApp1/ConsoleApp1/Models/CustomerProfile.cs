using System;
using System.Collections.Generic;
using System.Text;

namespace EFApp.Models
{
    public class CustomerProfile
    {
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }

        public int CustomerID { get; set; }

        public Customer Customer { get; set; }
    }
}
