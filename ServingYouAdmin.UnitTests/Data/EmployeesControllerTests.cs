using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using ServingYouAdmin.Controllers;
using ServingYouAdmin.Data;
using ServingYouAdmin.Enums;
using ServingYouAdmin.Models;
using ServingYouAdmin.Persistence;
using ServingYouAdmin.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ServingYouAdmin.UnitTests.Data
{
    [TestFixture]
    public class EmployeesControllerTests
    {
        private Mock<IEmployeeRepository> repository;
        private Mock<IUnitOfWork> unitOfWork;
        private EmployeesController controller;
        private Employee employee;

        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IEmployeeRepository>();
            unitOfWork = new Mock<IUnitOfWork>();
            controller = new EmployeesController(repository.Object, unitOfWork.Object);

            employee = new Employee
            {
                Id = 1,
                FirstName = "Sky",
                LastName = "B",
                Phone = "123 456 7890",                
                Email = "sky@domain.com",
                Position = Position.Manager,
                JobType = JobType.Fulltime,
                Postcode = "2000",
                StateCode = "NSW",
                Unit = "2",
                Street = "Queen",
                Town = "Sydney",
                IsDeleted = false,
                DateCreated = new DateTime(2020, 11, 11)
            };
        }

        [Test]
        public async Task Index_WhenCalled_ReturnAllEmployees()
        {
            // Arrange
            repository.Setup(r => r.GetAllEmployeeAsync()).ReturnsAsync(new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Sky",
                    LastName = "B",
                    Phone = "123 456 7890",
                    Email = "sky@domain.com",
                    Position = Position.Manager,
                    JobType = JobType.Fulltime,
                    Postcode = "2000",
                    StateCode = "NSW",
                    Unit = "2",
                    Street = "Queen",
                    Town = "Sydney",
                    IsDeleted = false,
                    DateCreated = new DateTime(2020, 11, 11),
                    DateUpdated = new DateTime(2020, 12, 04)
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Ocean",
                    LastName = "Breeze",
                    Phone = "111 2222 3333",
                    Email = "ocean@domain.com",
                    Position = Position.Waiter,
                    JobType = JobType.Parttime,
                    Postcode = "2000",
                    StateCode = "NSW",
                    Unit = "3",
                    Street = "KIng",
                    Town = "Sydney",
                    IsDeleted = false,
                    DateCreated = new DateTime(2020, 10, 12)                    
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Ocean",
                    LastName = "Breeze",
                    Phone = "111 2222 3333",
                    Email = "ocean@domain.com",
                    Position = Position.Waiter,
                    JobType = JobType.Parttime,
                    Postcode = "2000",
                    StateCode = "NSW",
                    Unit = "32",
                    Street = "Market",
                    Town = "Sydney",
                    IsDeleted = true,
                    DateCreated = new DateTime(2020, 10, 12),
                    DateUpdated = new DateTime(2020, 12, 30)
                }
            });

            // Act
            var result = await controller.Index() as ViewResult;
            var model = result.Model as List<Employee>;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Count, Is.EqualTo(3));
            Assert.That(model[2].IsDeleted, Is.True);
        }

        [Test]
        public async Task Create_WhenCalled_CreateEmployeeInDbAndRedirectToIndex()
        {
            // Arrange
            var model = new EmployeeCreateViewModel
            {   
                FirstName = "Ocean",
                LastName = "Breeze",
                Phone = "111 2222 3333",
                Email = "ocean@domain.com",
                Position = Position.Waiter,
                JobType = JobType.Parttime,
                Postcode = "2000",
                StateCode = "NSW",
                Unit = "32",
                Street = "Market",
                Town = "Sydney"               
            };

            // Act
            var result = await controller.Create(model) as RedirectToActionResult;

            // Assert
            repository.Verify(r => r.AddAsync(It.IsAny<Employee>()), Times.Once);
            unitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
            Assert.That(result.ActionName, Is.EqualTo("index").IgnoreCase);
        }

        [Test]
        [TestCase(null)]
        [TestCase(3)]
        public async Task Details_IfIdIsNullOrNotExist_ReturnNotFound(int? id)
        {
            // Arrange
            repository.Setup(r => r.GetEmployeeAsync(1)).ReturnsAsync(employee);

            // Act
            var result = await controller.Details(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Details_WhenCalled_ReturnEmployeeDetails()
        {
            // Arrange
            repository.Setup(r => r.GetEmployeeAsync(1)).ReturnsAsync(employee);

            // Act
            var result = await controller.Details(1) as ViewResult;
            var model = result.Model as Employee;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Id, Is.EqualTo(1));
            Assert.That(model.FirstName, Is.EqualTo("Sky").IgnoreCase);
        }


        [Test]
        public async Task Edit_WhenCalled_ReturnEmployee()
        {
            // Arrange               
            repository.Setup(r => r.GetEmployeeAsync(1)).ReturnsAsync(employee);

            // Act
            var result = await controller.Edit(1) as ViewResult;
            var model = result.Model as EmployeeEditViewModel;

            // Assert 
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Id, Is.EqualTo(1));
            Assert.That(model.Position, Is.EqualTo(Position.Manager));
        }

        [Test]
        public async Task Edit_WhenCalled_UpdateEmployeeAndRedirectToIndex()
        {
            // Arrange               
            repository.Setup(r => r.GetEmployeeAsync(1)).ReturnsAsync(employee);

            var model = new EmployeeEditViewModel
            {
                Id = 1,
                FirstName = "Ocean",
                LastName = "Breeze",
                Phone = "111 2222 3333",
                Email = "ocean@domain.com",
                Position = Position.Waiter,
                JobType = JobType.Parttime,
                Postcode = "2000",
                StateCode = "NSW",
                Unit = "100",
                Street = "Elizabeth",
                Town = "Sydney"
            };

            // Act            
            var result = await controller.Edit(model) as RedirectToActionResult;
            
            // Assert   
            repository.Verify(r => r.Update(employee), Times.Once);
            unitOfWork.Verify(u => u.CompleteAsync(), Times.Once);

            Assert.That(employee.Unit, Is.EqualTo("100"));
            Assert.That(result.ActionName, Is.EqualTo("index").IgnoreCase);
        }

        [Test]
        public async Task Delet_WhenCalled_UpdateIsDeletedColumnToTrueAndRedirectToIndex()
        {
            // Arrange
            repository.Setup(r => r.GetEmployeeAsync(1)).ReturnsAsync(employee);
            employee.IsDeleted = true;
            
            // Act
            var result = await controller.Delete(1) as RedirectToActionResult;

            // Assert
            repository.Verify(r => r.Update(employee), Times.Once);
            unitOfWork.Verify(u => u.CompleteAsync(), Times.Once);
            Assert.That(result.ActionName, Is.EqualTo("index").IgnoreCase);
        }
    }
}
