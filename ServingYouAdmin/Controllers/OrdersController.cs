
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServingYouAdmin.Data;
using ServingYouAdmin.Models;

namespace ServingYouAdmin.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrdersController(IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        // GET: Orders
        public async Task<IActionResult> Index(string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
            {
                startDate = DateTime.Now.AddDays(-7).ToShortDateString();
                endDate = DateTime.Now.ToShortDateString();
            }

            //Response.Headers.Add("Refresh", "300");
            return View(await orderRepository.GetAllOrdersAsync(
                                Convert.ToDateTime(startDate), 
                                Convert.ToDateTime(endDate)));
        }      

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderRepository.GetOrderDetailsAsync(id.Value);
               
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }                                                           

        // POST: Orders/Create        
        [HttpPost]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                await orderRepository.AddAsync(order);
                await unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await orderRepository.GetOrderAsync(id.Value);

            if (order == null)
            {
                return NotFound();
            }

            orderRepository.UpdateStatus(order);
            await unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
