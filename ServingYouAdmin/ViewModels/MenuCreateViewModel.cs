
using System;
using ServingYouAdmin.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ServingYouAdmin.ViewModels
{
    public class MenuCreateViewModel
    {        
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
        public decimal Price { get; set; }

        public bool Special { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        [Display(Name = "Special Price")]
        public decimal SpecialPrice { get; set; }

        public string Image { get; set; }

        [Required]
        public IFormFile ImageFile { get; set; }

    }
}
