using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServingYouAdmin.ViewModels;
using ServingYouAdmin.Data;
using ServingYouAdmin.Models;

namespace ServingYouAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IMemberRepository memberRepository;
        private readonly IMenuRepository menuRepository;
        private readonly IOrderRepository orderRepository;        

        public HomeController(
            ILogger<HomeController> logger,
            IMemberRepository memberRepository,
            IMenuRepository menuRepository,
            IOrderRepository orderRepository            
        )
        {
            this.logger = logger;
            this.memberRepository = memberRepository;
            this.menuRepository = menuRepository;
            this.orderRepository = orderRepository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Members = await memberRepository.GetNewMembersAsync(),
                Menus = await menuRepository.GetNewMenusAsync(),
                Orders = await orderRepository.GetNewOrdersAsync(),
                EmployeeId = User.Identity.Name
            };            

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
