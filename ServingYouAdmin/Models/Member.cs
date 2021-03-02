using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Models
{
    public class Member
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
                
        [Required]
        [MaxLength(15)]
        [RegularExpression(@"(?:\+?61)?(?:\(0\)[23478]|\(?0?[23478]\)?)\d{8}", ErrorMessage = "Invalid Phone Format")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9-.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalie Email Format")]
        public string Email { get; set; }
                
        public bool IsDeleted { get; set; }

        [DisplayName("Date Registered")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateRegistered { get; set; }

        public DateTime DateUpdated { get; set; }

        [DisplayName("Full Name")]
        public string FullName { get => $"{FirstName} {LastName}"; }

        public ICollection<Order> Orders { get; set; }
    }
}
