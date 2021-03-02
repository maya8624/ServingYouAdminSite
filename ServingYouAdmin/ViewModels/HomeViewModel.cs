using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServingYouAdmin.Models;

namespace ServingYouAdmin.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
        public IEnumerable<Member> Members { get; set; }
        public string EmployeeId { get; set; }
    }
}
