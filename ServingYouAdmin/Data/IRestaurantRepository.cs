using Microsoft.AspNetCore.Mvc.Rendering;
using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Data
{
    public interface IRestaurantRepository
    {
        Task<Restaurant> GetRestaurantAsync(int id);

        Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync();

        Task<IEnumerable<SelectListItem>> GetStatesAsync();

        void Add(Restaurant restaurant);

        void Update(Restaurant restaurant);
    }
}
