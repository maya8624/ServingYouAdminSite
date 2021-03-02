using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServingYouAdmin.Data;
using ServingYouAdmin.Models;
using ServingYouAdmin.ViewModels;

namespace ServingYouAdmin.Controllers
{    
    public class BookingsController : Controller
    {        
        private readonly IBookingRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public BookingsController(IBookingRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        // GET: Bookings
        public async Task<IActionResult> Index(string startDate, string endDate)
        {      
            if (string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
            {
                startDate = DateTime.Now.AddDays(-7).ToShortDateString();
                endDate = DateTime.Now.ToShortDateString();
            }                       
                        
            var bookings = await repository.GetBookingsAsync(
                                Convert.ToDateTime(startDate), 
                                Convert.ToDateTime(endDate));

            return View(bookings);
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await repository.GetBooking(id.Value);

            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        public async Task<IActionResult> Create(BookingCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var booking = new Booking
                {                 
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Mobile = model.Mobile,
                    DateBooked = model.DateBooked,
                    TimeBooked = model.TimeBooked,
                    NumberinParty = model.NumberinParty,
                    Status = model.Status,
                    Method = model.Method,
                    TableNo = model.TableNo,
                    DateCreated = DateTime.Now,                    
                };

                await repository.AddAsync(booking);
                await unitOfWork.CompleteAsync();

                return RedirectToAction("details", new { id = booking.Id });                
            }
            return View();
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await repository.GetBooking(id.Value);

            if (booking == null)
            {
                return NotFound();
            }

            var bookingEditViewModel = new BookingEditViewModel
            {
                Id = booking.Id,
                FirstName = booking.FirstName,
                LastName = booking.LastName,
                Mobile = booking.Mobile,
                DateBooked = booking.DateBooked,
                TimeBooked = booking.TimeBooked,
                NumberinParty = booking.NumberinParty,
                Status = booking.Status,
                Method = booking.Method,
                TableNo = booking.TableNo,
            };            
            
            return View(bookingEditViewModel);
        }

        // POST: Bookings/Edit/5
        [HttpPost]        
        public async Task<IActionResult> Edit(BookingEditViewModel model)
        {          
            if (ModelState.IsValid)
            {
                var booking = await repository.GetBooking(model.Id);

                booking.FirstName = model.FirstName;
                booking.LastName = model.LastName;
                booking.Mobile = model.Mobile;
                booking.DateBooked = model.DateBooked;
                booking.TimeBooked = model.TimeBooked;
                booking.NumberinParty = model.NumberinParty;
                booking.Status = model.Status;
                booking.Method = model.Method;
                booking.TableNo = model.TableNo;
                booking.DateUpdated = DateTime.Now;

                repository.Update(booking);
                await unitOfWork.CompleteAsync();              
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
    }
}
