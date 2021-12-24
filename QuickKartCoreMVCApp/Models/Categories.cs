using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuickKartCoreMVCApp.Models
{
    public class Categories
    {
        [Required]
        public byte CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
    }
}
