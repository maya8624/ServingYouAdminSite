
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ServingYouAdmin.ViewModels
{
    public class RestaurantEditViewModel : RestaurantCreateViewModel
    {
        public int Id { get; set; }       
    }
}
