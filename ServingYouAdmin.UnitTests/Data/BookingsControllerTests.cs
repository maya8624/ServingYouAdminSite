using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ServingYouAdmin.Controllers;
using ServingYouAdmin.Data;
using ServingYouAdmin.Models;
using ServingYouAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServingYouAdmin.UnitTests.Data
{
    [TestFixture]
    public class BookingsControllerTests
    {
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IBookingRepository> repository;
        private BookingsController controller;
        private Booking booking; 

        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IBookingRepository>();
            unitOfWork = new Mock<IUnitOfWork>();
            controller = new BookingsController(repository.Object, unitOfWork.Object);

            booking = new Booking
            {
                Id = 1,
                FirstName = "Joseph",
                LastName = "K",
                Mobile = "123456789",
                DateBooked = new DateTime(2020, 12, 22),
                TimeBooked = "12:30",
                Status = 1,
                NumberinParty = 5,
                Method = 1,
                TableNo = 1,
                EmployeeId = 1,
                DateCreated = new DateTime(2020, 12, 20)
            };
        }

        [Test]
        public async Task Index_WhenCalled_ReturnAllBookings()
        {
            // Arrange
            repository.Setup(r => r.GetBookingsAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(new List<Booking>
            {
                new Booking
                {
                    Id = 1,
                    FirstName = "Andy",
                    LastName = "J",
                    Mobile = "123456789",
                    DateBooked = new DateTime(2020, 12, 22),
                    TimeBooked = "12:30",
                    Status = 1,
                    NumberinParty = 5,
                    Method = 1,
                    TableNo = 1,
                    EmployeeId = 1,
                    DateCreated = new DateTime(2020, 12, 20)
                },
                new Booking
                {
                    Id = 2,
                    FirstName = "Joseph",
                    LastName = "K",
                    Mobile = "123456789",
                    DateBooked = new DateTime(2021, 02, 22),
                    TimeBooked = "12:30",
                    Status = 1,
                    NumberinParty = 5,
                    Method = 1,
                    TableNo = 1,
                    EmployeeId = 1,
                    DateCreated = new DateTime(2020, 12, 20)
                },
                new Booking
                {
                    Id = 3,
                    FirstName = "Jimmy",
                    LastName = "Kim",
                    Mobile = "123456789",
                    DateBooked = new DateTime(2020, 12, 22),
                    TimeBooked = "12:30",
                    Status = 1,
                    NumberinParty = 5,
                    Method = 1,
                    TableNo = 1,
                    EmployeeId = 1,
                    DateCreated = new DateTime(2020, 12, 20)
                }
            });
                   

            // Act
            var result = await controller.Index(It.IsAny<string>(), It.IsAny<string>()) as ViewResult;
            var model = result.Model as List<Booking>;

            // Assert 
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Count, Is.EqualTo(3));
        }

        [Test]
        public async Task Create_WhenCalled_CreateNewBookingAndRedirectToIndex()
        {
            // Arrange           
            var model = new BookingCreateViewModel
            {
                FirstName = "Joseph",
                LastName = "A",
                Mobile = "123456789",
                DateBooked = new DateTime(2020, 12, 21),
                TimeBooked = "13:30",
                NumberinParty = 3,
                Status = 1,
                Method = 2,
                TableNo = 1,              
            };

            // Act
            var result = await controller.Create(model) as RedirectToActionResult;

            // Assert 
            Assert.That(result.RouteValues.Count, Is.EqualTo(1));
            Assert.That(result.ActionName, Is.EqualTo("details"));

        }

        [Test]
        public async Task Edit_WhenCalled_ReturnBookingEditViewModel()
        {
            // Arrange   
            repository.Setup(r => r.GetBooking(1)).ReturnsAsync(booking);

            // Act
            var result = await controller.Edit(1) as ViewResult;
            var model = result.Model as BookingEditViewModel;

            // Assert 
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task Edit_WhenCalled_UpdateBookingAndRedirectToIndex()
        {
            // Arrange         
            repository.Setup(r => r.GetBooking(1)).ReturnsAsync(booking);            

            var model = new BookingEditViewModel
            {
                Id = 1,
                FirstName = "Joseph",
                LastName = "A",
                Mobile = "123456789",
                DateBooked = new DateTime(2020, 12, 21),
                TimeBooked = "13:30",
                NumberinParty = 3,
                Status = 1,
                Method = 2,
                TableNo = 1,
            };

            // Act
            var result = await controller.Edit(model) as RedirectToActionResult;

            // Assert             
            repository.Verify(r => r.Update(booking));
            Assert.That(result.ActionName, Is.EqualTo("index").IgnoreCase);
        }
    }
}
