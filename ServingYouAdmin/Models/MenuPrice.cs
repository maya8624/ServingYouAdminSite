using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Models
{
    public class MenuPrice
    {
        public int Id { get; set; }
        public int MenuId { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
