using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRestfulWebshop.EF.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; }

        public int Amount { get; set; }

        public decimal PriceAtOrderDate { get; set; }

    }
}
