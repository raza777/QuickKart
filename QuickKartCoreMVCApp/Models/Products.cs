using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickKartCoreMVCApp.Models
{
    public class Products
    {
        [Required]
        public Nullable<byte> CategoryId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ProductId { get; set; }

        [MinLength(3)]
        [Required]
        public string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        [Required]
        public int QuantityAvailable { get; set; }


    }
}
