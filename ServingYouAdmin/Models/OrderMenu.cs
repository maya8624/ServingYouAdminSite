using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Models
{
    public class OrderMenu
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int MenuId { get; set; }

        public Menu Menu { get; set; }

        public int Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        public DateTime DateCreated { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Subtotal { get => Quantity * Price; }
    }
}
