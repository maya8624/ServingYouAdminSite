using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServingYouAdmin.Models;
using ServingYouAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Data
{
    public class SqlRestaurantRepository : IRestaurantRepository
    {
        private readonly ServingYouContext context;

        public SqlRestaurantRepository(ServingYouContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SelectListItem>> GetStatesAsync()
        {
            var states = await context.States.Select(s => 
                new SelectListItem()
                {   
                    Value = s.Code,
                    Text = s.Name            
                }).ToListAsync();

            return states;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurantsAsync()
        {
            return await context.Restaurants.ToListAsync();            
        }

        public async Task<Restaurant> GetRestaurantAsync(int id)
        {
           return await context.Restaurants.FindAsync(id);

        }

        public void Update(Restaurant restaurantChanges)
        {
            var restaurant = context.Restaurants.Attach(restaurantChanges);
            restaurant.State = EntityState.Modified;
        }

        public void Add(Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
        }
    }
}
