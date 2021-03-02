using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.ViewModels
{
    public class OrderCreateViewModel
    {
        [Required]
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DisplayName("Status")]
        public int OrderStatus { get; set; }

        public string Details { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        public decimal Total { get; set; }
        
        public List<Menu> Menus { get; set; }
    }
}
