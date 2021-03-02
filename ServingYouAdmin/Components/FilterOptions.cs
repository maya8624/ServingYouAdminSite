using Microsoft.AspNetCore.Mvc;
using ServingYouAdmin.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Components
{
    public class FilterOptions : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var filters = new FilterByDates
            {
                StartDate = DateTime.Today.AddDays(-7).ToString("yyyy-MM-dd"),
                EndDate = DateTime.Today.ToString("yyyy-MM-dd")
            };

            return View(filters);
        }
    }
}
