using Moq;
using NUnit.Framework;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Collections.Generic;
using ServingyouAdmin.Classes;
using ServingYouAdmin.Controllers;
using ServingYouAdmin.Data;
using ServingYouAdmin.Enums;
using ServingYouAdmin.Models;
using ServingYouAdmin.ViewModels;

namespace ServingYouAdmin.UnitTests.Data
{
    [TestFixture]
    public class MenusControllerTests
    {
        private Mock<IFuncs> funcs;
        private Mock<IUnitOfWork> unitOfWork;
        private Mock<IMenuRepository> repository;
        private Mock<IWebHostEnvironment> webHostEnvironment;
        private MenusController controller;
        private List<Menu> menus;
        private Menu menu;

        [SetUp]
        public void SetUp()
        {
            funcs = new Mock<IFuncs>();
            repository = new Mock<IMenuRepository>();
            unitOfWork = new Mock<IUnitOfWork>();
            webHostEnvironment = new Mock<IWebHostEnvironment>();
            webHostEnvironment.SetupProperty(s => s.WebRootPath, "wwwroot");    
                       
            controller = new MenusController(funcs.Object, repository.Object, unitOfWork.Object, webHostEnvironment.Object);           

             menu = new Menu
            {
                Id = 1,
                Name = "menu",
                Description = "Desc",
                Category = MenuCategory.Australian,
                Available = true,
                Price = 18.50m,
                Special = true,
                SpecialPrice = 15,
                Image ="test.jpg"
             };

            menus = new List<Menu>
            {
                new Menu
                {
                    Id = 1,
                    Name = "menu",
                    Description = "Desc",
                    Category = MenuCategory.Australian,
                    Available = true,
                    Price = 18.50m,
                    Special = false,
                    SpecialPrice = 0,
                    Image ="test.jpg"
                },
                new Menu
                {
                    Id = 2,
                    Name = "menu2",
                    Description = "Desc2",
                    Category = MenuCategory.Japanes,
                    Available = true,
                    Price = 17.50m,
                    Special = true,
                    SpecialPrice = 15,
                    Image ="test.jpg"
                }
            };
        }

        //[Test]
        //public async Task Index_WhenCalled_ReturnList()            
        //{

        //    //return await PaginatedList<Menu>.CreateAsync(menus.AsNoTracking(), pageNumber ?? 1);
        //    repository.Setup(r => r.GetAll("", string.Empty, string.Empty, 0)).ReturnsAsync(new PaginatedList<Menu>(menus, 2, 1, 1)
        //    {
        //      menus
        //    });

        //   // Act
        //   var result = await controller.Index(string.Empty, string.Empty, string.Empty, string.Empty, null) as ViewResult;
        //    var model = result.Model as Menu;

        //}

        [Test]
        public async Task Create_WhenCalled_CreateMenuAndRedirectionToDetails()
        {
            // Arrange
            var model = new MenuCreateViewModel
            {
                Name = "Spice Curry",
                Description = "Absolute Yum",
                Available = true,
                Category = MenuCategory.Thailand,
                Price = 19.99m,
                Special = true,
                SpecialPrice = 15,
                ImageFile = null
            };

            // Act
            var result = await controller.Create(model) as RedirectToActionResult;

            // Assert
            repository.Verify(r => r.AddSync(It.IsAny<Menu>()), Times.Once);
            unitOfWork.Verify(u => u.CompleteAsync(), Times.Once());
            Assert.That(result.ActionName, Is.EqualTo("details").IgnoreCase);
        }

        [Test]
        public async Task Details_IdIsNull_ReturnNotFound()
        {
            var result = await controller.Details(null);
                    
            Assert.That(result, Is.InstanceOf<NotFoundResult>());           
        }

        [Test]
        [TestCase(null)]
        [TestCase(2)]
        public async Task Details_IfIdIsNullOrNotExist_ReturnNotFound(int? id)
        {
            // Arrange
            repository.Setup(r => r.GetMenuAsync(1)).ReturnsAsync(menu);

            // Act
            var result = await controller.Details(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Details_WhenCalled_ReturnMenuDetails()
        {            
            repository.Setup(r => r.GetMenuAsync(1)).ReturnsAsync(menu);

            // Act
            var result = await controller.Details(1) as ViewResult;
            var model = result.Model as Menu;

            // Assert 
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Category, Is.EqualTo(MenuCategory.Australian));
        }

        [Test]
        public async Task Edit_WhenCalled_UpdateMenuAndRedirectToIndex()
        {
            // Arrange               
            repository.Setup(r => r.GetMenuAsync(1)).ReturnsAsync(menu);

            var model = new MenuEditViewModel
            {
                Id = 1,
                Name = "Double Mac Meal",
                Description = "Fast Food",
                Category = MenuCategory.Australian,
                Available = true,
                Price = 11.50m,
                Special = false,
                SpecialPrice = 0,
                ImageFile = null
            };

            // Act            
            var result = await controller.Edit(model) as  RedirectToActionResult;
            
            // Assert 
            repository.Verify(r => r.Update(menu), Times.Once);
            unitOfWork.Verify(u => u.CompleteAsync(), Times.Once);

            Assert.That(menu.Price, Is.EqualTo(11.50m));
            Assert.That(menu.Name, Is.EqualTo("Double Mac Meal").IgnoreCase);
            Assert.That(result.ActionName, Is.EqualTo("Details").IgnoreCase);
        }
    }
}
