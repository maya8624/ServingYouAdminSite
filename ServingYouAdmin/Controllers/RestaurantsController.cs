using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServingYouAdmin.Data;
using ServingYouAdmin.Models;
using ServingYouAdmin.ViewModels;

namespace ServingYouAdmin.Controllers
{
    public class RestaurantsController : Controller
    {        
        private readonly IRestaurantRepository repository;
        private readonly IUnitOfWork unitOfWork;
              

        public RestaurantsController(IRestaurantRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        // GET: Restaurant
        public async Task<IActionResult> Index()
        {  
            return View(await repository.GetAllRestaurantsAsync());           
        }

        // GET: Restaurant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await repository.GetRestaurantAsync(id.Value);

            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // GET: Restaurant/Create
        public async Task<IActionResult> Create()
        {
            var restaurant = new RestaurantCreateViewModel
            {
                StateList = await repository.GetStatesAsync()
            };

            return View(restaurant);
        }

        // POST: Restaurant/Create
        [HttpPost]
        public async Task<IActionResult> Create (RestaurantCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant
                {
                    Name = model.Name,
                    Phone = model.Phone,
                    Email = model.Email,
                    Description = model.Description,
                    Postcode = model.Postcode,
                    Unit = model.Unit,
                    Street = model.Street,
                    Town = model.Town,
                    StateCode = model.StateCode,
                    DateUpdated = DateTime.Now
                };

                repository.Add(restaurant);
                await unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Restaurant/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var restaurant = await repository.GetRestaurantAsync(id.Value);

            if (restaurant == null)
            {
                return NotFound();
            }
            
            var restaurantEditViewModel = new RestaurantEditViewModel
            {
                Id = restaurant.Id,
                Name = restaurant.Name,
                Phone = restaurant.Phone,
                Email = restaurant.Email,
                Description = restaurant.Description,
                Postcode = restaurant.Postcode,
                Unit = restaurant.Unit,
                Street = restaurant.Street,
                Town = restaurant.Town,
                StateCode = restaurant.StateCode,
                StateList = await repository.GetStatesAsync()
            };            

            return View(restaurantEditViewModel);
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = await repository.GetRestaurantAsync(model.Id);

                restaurant.Name = model.Name;
                restaurant.Phone = model.Phone;
                restaurant.Email = model.Email;
                restaurant.Description = model.Description;
                restaurant.Postcode = model.Postcode;
                restaurant.Unit = model.Unit;
                restaurant.Street = model.Street;
                restaurant.Town = model.Town;
                restaurant.StateCode = model.StateCode;
                restaurant.DateUpdated = DateTime.Now;

                repository.Update(restaurant);
                await unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }
            else
            {
                model.StateList = await repository.GetStatesAsync();
            }

            return View(model);
        }     
    }
}
