using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using ServingYouAdmin.Data;
using ServingYouAdmin.Models;
using ServingYouAdmin.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServingYouAdmin.ViewModels;

namespace ServingYouAdmin.UnitTests.Data
{
    [TestFixture]
    public class RestaurantsControllerTests
    {
        private Mock<IRestaurantRepository> repository;
        private Mock<IUnitOfWork> unitOfWork;
        private RestaurantsController controller;
        private Restaurant restaurant;

        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IRestaurantRepository>();
            unitOfWork = new Mock<IUnitOfWork>();
            controller = new RestaurantsController(repository.Object, unitOfWork.Object);
            restaurant = new Restaurant
            {
                Id = 1,
                Name = "Serving You",
                Phone = "02 1111 2222",
                Email = "admin@servingyou.com.au",
                Description = "Fantastic Restaurant",
                Postcode = "2000",
                StateCode = "NSW",
                Unit = "1",
                Street = "Queen",
                Town = "Sydney",
                DateCreated = new DateTime(2020, 11, 1)
            };
        }

        [Test]
        public async Task Index_WhenCalled_ReturnAllCustomers()
        {
            // Arrange
            repository.Setup(r => r.GetAllRestaurantsAsync()).ReturnsAsync(new List<Restaurant>
            {
               restaurant
            });

            // Act
            var result = await controller.Index() as ViewResult;
            var model = result.Model as List<Restaurant>;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Count, Is.EqualTo(1));
            Assert.That(model[0].Name, Is.EqualTo("Serving You").IgnoreCase);
        }

        [Test]
        public async Task Create_WhenCalled_CreateCustomerInDbAndRedirectToIndex()
        {
            // Arrange
            var model = new  RestaurantCreateViewModel
            {
                Name = "Serving You",
                Phone = "02 1111 2222",
                Email = "admin@servingyou.com.au",
                Description = "Fantastic Restaurant",
                Postcode = "2000",
                StateCode = "NSW",
                Unit = "1",
                Street = "Queen",
                Town = "Sydney",
                //DateCreated = new DateTime(2020, 11, 1)
            };

            // Act
            var result = await controller.Create(model) as RedirectToActionResult;

            // Assert
            repository.Verify(r => r.Add(It.IsAny<Restaurant>()), Times.Once);
            unitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
            Assert.That(result.ActionName, Is.EqualTo("index").IgnoreCase);
        }

        [Test]
        [TestCase(null)]
        [TestCase(2)]
        public async Task Details_IfIdIsNullOrNotExistIn_ReturnNotFound(int? id)
        {
            // Arrange
            repository.Setup(r => r.GetRestaurantAsync(1)).ReturnsAsync(restaurant);

            // Act
            var result = await controller.Details(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Edit_WhenCalled_ReturnRestaurant()
        {            
            // Arrange               
            repository.Setup(r => r.GetRestaurantAsync(1)).ReturnsAsync(restaurant);

            // Act
            var result = await controller.Edit(1) as ViewResult;
            var model = result.Model as RestaurantEditViewModel;

            // Assert 
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Id, Is.EqualTo(1));
        }

        [Test]
        public async Task Edit_WhenCalled_UpdateCustomerAndRedirectToIndex()
        {
            // Arrange               
            repository.Setup(r => r.GetRestaurantAsync(1)).ReturnsAsync(restaurant);

            var model = new RestaurantEditViewModel
            {
                Id = 1,
                Name = "Serving You",
                Phone = "02 1111 2222",
                Email = "admin@servingyou.com.au",
                Description = "Fantastic Restaurant",
                Postcode = "2000",
                Unit = "3",
                Street = "Market",
                Town = "Sydney",
                StateCode = "NSW"
            };

            // Act            
            var result = await controller.Edit(model) as RedirectToActionResult;

            // Assert 
            Assert.That(restaurant.Street, Is.EqualTo("Market").IgnoreCase);

            repository.Verify(r => r.Update(restaurant), Times.Once);
            unitOfWork.Verify(u => u.CompleteAsync(), Times.Once);

            Assert.That(result.ActionName, Is.EqualTo("Index").IgnoreCase);
        }
    }
}
