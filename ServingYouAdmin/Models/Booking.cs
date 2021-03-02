using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(15)]
        [RegularExpression(@"(?:\+?61)?(?:\(0\)[23478]|\(?0?[23478]\)?)\d{8}", ErrorMessage = "Invalid Phone Format")]
        public string Mobile { get; set; }

        [Required]
        [DisplayName("Date Booked")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime DateBooked { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("Time")]        
        public string TimeBooked { get; set; }

        [Required]
        public int Status { get; set;}

        [Required]
        [DisplayName("Number in Party")]            
        [Range(1, 20)]
        public int NumberinParty { get; set; }

        [Required]
        public int Method { get; set; }
        
        [DisplayName("Date Created")]        
        public DateTime DateCreated { get; set; }
                
        [DisplayName("Date Updated")]
        public DateTime DateUpdated { get; set; }
        
        [Required]        
        [DisplayName("Table")]
        public int TableNo { get; set; }
        
        public int EmployeeId { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get => $"{FirstName} {LastName}"; }
    }
}
