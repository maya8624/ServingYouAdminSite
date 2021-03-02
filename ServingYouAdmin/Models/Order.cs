using ServingYouAdmin.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServingYouAdmin.Models

{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Order Date")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime OrderDate { get; set; }

        [Required]
        [DisplayName("Status")]
        public OrderStatus OrderStatus { get; set; }

        [Required]
        [DisplayName("Methods")]
        public OrderMethods OrderMethod { get; set; }
        
        [Required]
        [DisplayName("Order Total")]    
        [Column(TypeName="decimal(6,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal OrderTotal { get; set; }

        public int EmployeeId { get; set; } 

        public int MemberId { get; set; }

        public Member Member { get; set; }

        public ICollection<OrderMenu> OrderMenu { get; set; }
    }
}
