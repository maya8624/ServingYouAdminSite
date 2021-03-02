using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ServingYouAdmin.Controllers;
using ServingYouAdmin.Data;
using ServingYouAdmin.Enums;
using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServingYouAdmin.UnitTests.Data
{
    [TestFixture]
    public class OrdersControllerTests
    {
        private Mock<IOrderRepository> repository;
        private Mock<IUnitOfWork> unitOfWork;
        private OrdersController controller;
        private Order order;

        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IOrderRepository>();
            unitOfWork = new Mock<IUnitOfWork>();
            controller = new OrdersController(repository.Object, unitOfWork.Object);

            order = new Order
            {
                Id = 1,
                OrderDate = new DateTime(2020, 12, 5),
                OrderStatus = OrderStatus.Confirmed,
                OrderTotal = 120.50m,
                EmployeeId = 100,
                MemberId = 200
            };
        }

        [Test]
        public async Task Index_WhenCalled_ReturnAllOrders()
        {
            // Arrange
            repository.Setup(r => r.GetAllOrdersAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(new List<Order>
            {
                new Order
                {
                    Id = 1,            
                    OrderDate = new DateTime(2020, 12, 9),
                    OrderStatus = OrderStatus.Completed,
                    OrderTotal = 55.00m,
                    EmployeeId = 100,
                    MemberId = 201
                },       
                new Order
                {
                    Id = 2,
                    OrderDate = new DateTime(2020, 12, 15),
                    OrderStatus = OrderStatus.Completed,
                    OrderTotal = 120.50m,
                    EmployeeId = 100,
                    MemberId = 200
                },
                new Order
                {
                    Id = 3,
                    OrderDate = new DateTime(2020, 12, 25),
                    OrderStatus = OrderStatus.Completed,
                    OrderTotal = 99.10m,
                    EmployeeId = 101,
                    MemberId = 203
                }
            });

            // Act
            var result = await controller.Index(It.IsAny<string>(), It.IsAny<string>()) as ViewResult;
            var model = result.Model as List<Order>;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Count, Is.EqualTo(3));
            Assert.That(model[2].MemberId, Is.EqualTo(203));
        }

        [Test]
        public async Task Create_WhenCalled_CreateOrderInDbAndRedirectToIndex()
        {
            // Arrange
            var model = new Order
            {
                OrderDate = new DateTime(2020, 12, 27),
                OrderStatus = OrderStatus.Confirmed,
                OrderTotal = 99.10m,
                EmployeeId = 101,
                MemberId = 203
            };

            // Act
            var result = await controller.Create(model) as RedirectToActionResult;

            // Assert
            repository.Verify(r => r.AddAsync(It.IsAny<Order>()), Times.Once);
            unitOfWork.Verify(u => u.CompleteAsync(), Times.Once);

            Assert.That(result.ActionName, Is.EqualTo("index").IgnoreCase);
        }

        [Test]
        [TestCase(null)]
        [TestCase(2)]
        public async Task Details_IfIdNotExist_ReturnNotFound(int? id)
        {
            // Arrange
            repository.Setup(r => r.GetOrderDetailsAsync(1)).ReturnsAsync(order);

            // Act
            var result = await controller.Details(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Details_WhenCalled_ReturnOrderDetails()
        {
            // Arrange
            repository.Setup(r => r.GetOrderDetailsAsync(1)).ReturnsAsync(order);

            // Act
            var result = await controller.Details(1) as ViewResult;
            var model = result.Model as Order;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Id, Is.EqualTo(1));
            Assert.That(model.OrderDate, Is.EqualTo(new DateTime(2020, 12, 5)));
        }

        [Test]
        [TestCase(null)]
        [TestCase(2)]
        public async Task UpdateStatus_IfIdIsNullOrNotExist_ReturnNotFound(int? id)
        {
            // Arrange
            repository.Setup(r => r.GetOrderAsync(1)).ReturnsAsync(order);

            // Act
            var result = await controller.Details(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }


        [Test]
        public async Task UpdateStatus_WhenCalled_UpdateOrderStatusToCompletedAndRedirectToIndex()
        {
            // Arrange
            repository.Setup(r => r.GetOrderAsync(1)).ReturnsAsync(order);
            order.OrderStatus = OrderStatus.Completed;

            // Act
            var result = await controller.UpdateStatus(1) as RedirectToActionResult;

            // Assert
            Assert.That(order.OrderStatus, Is.EqualTo(OrderStatus.Completed));

            repository.Verify(r => r.UpdateStatus(order), Times.Once);
            unitOfWork.Verify(u => u.CompleteAsync(), Times.Once);

            Assert.That(result.ActionName, Is.EqualTo("index").IgnoreCase);
        }
    }
}
