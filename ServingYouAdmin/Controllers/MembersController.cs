using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServingYouAdmin.Data;
using ServingYouAdmin.Models;
using ServingYouAdmin.ViewModels;

namespace ServingYouAdmin.Controllers
{
    public class MembersController : Controller
    {
        private readonly IMemberRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public MembersController(IMemberRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        // GET: Member
        public async Task<IActionResult> Index(string startDate, string endDate)
        {
            if (string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate))
            {
                startDate = DateTime.Now.AddDays(-7).ToShortDateString();
                endDate = DateTime.Now.ToShortDateString();
            }

            return View(await repository.GetAllMembersAsync(
                                Convert.ToDateTime(startDate), 
                                Convert.ToDateTime(endDate)));
        }

        // GET: Member/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await repository.GetMemberAsync(id.Value);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public async Task<IActionResult> Create(MemberCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var member = new Member
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    Email = model.Email,                   
                    DateRegistered = DateTime.Now
                };

                await repository.AddAsync(member);
                await unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Member/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var member = await repository.GetMemberAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            var memberEditViewModel = new MemberEditViewModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Phone = member.Phone,
                Email = member.Email
            };

            return View(memberEditViewModel);
        }

        // POST: Member/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(MemberEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var member = await repository.GetMemberAsync(model.Id);

                member.FirstName = model.FirstName;
                member.LastName = model.LastName;
                member.Phone = model.Phone;
                member.Email = model.Email;
                member.DateUpdated = DateTime.Now;

                repository.Update(member);
                await unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}
