using ServingYouAdmin.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.ViewModels
{
    public class EmployeeCreateViewModel
    {
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
        public string Phone { get; set; }

        [Required]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9-.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalie Email Format")]
        public string Email { get; set; }

        [Required]
        public Position Position { get; set; }

        [Required]
        [DisplayName("Job Type")]
        public JobType JobType { get; set; }

        [Required]
        [MaxLength(4)]
        public string Postcode { get; set; }

        [Required]
        [DisplayName("State")]
        public string StateCode { get; set; }

        [Required]
        [MaxLength(10)]
        public string Unit { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required]
        [MaxLength(30)]
        public string Town { get; set; }

    }
}
