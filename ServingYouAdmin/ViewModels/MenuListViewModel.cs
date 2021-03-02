using Microsoft.AspNetCore.Mvc.Rendering;
using ServingYouAdmin.Classes;
using ServingYouAdmin.Enums;
using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.ViewModels
{
    public class MenuListViewModel
    {
        public PaginatedList<Menu> Menus { get; set; }
        public string SortOrder { get; set; }
        public string CurrentSortOrder { get; set; }
        public string Category { get; set; }
        public string SearchString { get; set; }                
    }
}
