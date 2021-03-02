using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServingYouAdmin.Data;
using ServingYouAdmin.Models;
using ServingYouAdmin.ViewModels;

namespace ServingYouAdmin.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public EmployeesController(IEmployeeRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            return View(await repository.GetAllEmployeeAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await repository.GetEmployeeAsync(id.Value);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {   
            if (ModelState.IsValid)
            {
                var employee = new Employee()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Phone = model.Phone,
                    Email = model.Email,
                    Position = model.Position,
                    JobType = model.JobType,
                    Unit = model.Unit,
                    Street = model.Street,
                    Town = model.Town,
                    StateCode = model.StateCode,
                    Postcode = model.Postcode,
                    DateCreated = DateTime.Now
                };

                await repository.AddAsync(employee);
                await unitOfWork.CompleteAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Employee/Edit/5
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await repository.GetEmployeeAsync(id.Value);
            
            if (employee == null)
            {
                return NotFound();
            }

            var employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Phone = employee.Phone,
                Email = employee.Email,
                Position = employee.Position,
                JobType = employee.JobType,
                Unit = employee.Unit,
                Street = employee.Street,
                Town = employee.Town,
                StateCode = employee.StateCode,
                Postcode = employee.Postcode,
            };

            return View(employeeEditViewModel);
        }

        // POST: Employee/Edit/5        
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeEditViewModel model)
        {            
            if (ModelState.IsValid)
            {
                var employee = await repository.GetEmployeeAsync(model.Id);

                employee.FirstName = model.FirstName;
                employee.LastName = model.LastName;
                employee.Phone = model.Phone;
                employee.Email = model.Email;
                employee.Position = model.Position;
                employee.JobType = model.JobType;
                employee.Unit = model.Unit;
                employee.Street = model.Street;
                employee.Town = model.Town;
                employee.StateCode = model.StateCode;
                employee.Postcode = model.Postcode;
                employee.DateUpdated = DateTime.Now;

                repository.Update(employee);

                await unitOfWork.CompleteAsync();             

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
      
        // POST: Employee/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await repository.GetEmployeeAsync(id);            
            employee.IsDeleted = true;
            
            repository.Update(employee);

            await unitOfWork.CompleteAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
