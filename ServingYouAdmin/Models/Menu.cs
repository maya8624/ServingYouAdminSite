
using ServingYouAdmin.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServingYouAdmin.Models
{
    public class Menu
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        [Required]
        public bool Available { get; set; }
        
        [Required]
        public MenuCategory Category { get; set; }

        [Required]
        [Column(TypeName = "decimal(6,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Price { get; set; }

        public bool Special { get; set; }

        [Display(Name = "Special Price")]
        [Column(TypeName = "decimal(6,2)")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SpecialPrice { get; set; }

        [Required]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Created Date")]
        public DateTime DateCreated { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Display(Name = "Updated Date")]
        public DateTime DateUpdated { get; set; }

        public ICollection<OrderMenu> OrderMenu { get; set; }   
    }
}
