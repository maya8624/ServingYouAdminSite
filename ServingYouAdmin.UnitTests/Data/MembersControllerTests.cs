using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using ServingYouAdmin.Data;
using ServingYouAdmin.Controllers;
using System.Threading.Tasks;
using ServingYouAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using ServingYouAdmin.ViewModels;

namespace ServingYouAdmin.UnitTests.Data
{
    [TestFixture]
    public class MembersControllerTests
    {
        private Mock<IMemberRepository> repository;
        private Mock<IUnitOfWork> unitOfWork;
        private MembersController controller;
        private Member member;

        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IMemberRepository>();
            unitOfWork = new Mock<IUnitOfWork>();

            controller = new MembersController(repository.Object, unitOfWork.Object);

            member = new Member
            {
                Id = 3,
                FirstName = "Sky",
                LastName = "B",
                Phone = "123 456 7890",               
                Email = "sky@domain.com",
                IsDeleted = false,
                DateRegistered = new DateTime(2020, 11, 11)
            };
        }

        [Test]
        public async Task Index_WhenCalled_ReturnAllCustomers()
        {
            // Arrange
            repository.Setup(r => r.GetAllMembersAsync(It.IsAny<DateTime>(), It.IsAny<DateTime>())).ReturnsAsync(new List<Member>
            {
                new Member
                {
                   FirstName = "Jimmy",
                   LastName = "K",
                   Phone = "123 456 7890",
                   Email = "jimmy@domain.com",                 
                   IsDeleted = false,
                   DateRegistered = new DateTime(2020, 12, 23),
                },
                new Member
                {
                   FirstName = "Joseph",
                   LastName = "J",
                   Phone = "123 456 7890",
                   Email = "joseph@domain.com",                   
                   IsDeleted = true,
                   DateRegistered = new DateTime(2020, 12, 01),
                },
                new Member
                {
                   FirstName = "Sky",
                   LastName = "B",
                   Phone = "123 456 7890",
                   Email = "sky@domain.com",                   
                   IsDeleted = false,
                   DateRegistered = new DateTime(2020, 11, 11),
                }
            });

            // Act
            var result = await controller.Index(It.IsAny<string>(), It.IsAny<string>()) as ViewResult;
            var model = result.Model as List<Member>;

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Count, Is.EqualTo(3));
            Assert.That(model[1].IsDeleted, Is.True);
        }

        [Test]
        public async Task Create_WhenCalled_CreateMemberInDbAndRedirectToIndex()
        {
            // Arrange
            var model = new MemberCreateViewModel
            {                
                FirstName = "Andy",
                LastName = "King",
                Phone = "134 2456 7890",
                Email = "andyk@domain.com"
            };

            // Act
            var result = await controller.Create(model) as RedirectToActionResult;
            
            // Assert
            repository.Verify(r => r.AddAsync(It.IsAny<Member>()), Times.Once);
            Assert.That(result.ActionName, Is.EqualTo("index").IgnoreCase);
        }                

        [Test]
        [TestCase(null)]
        [TestCase(1)]
        public async Task Details_IfIdIsNullOrNotExistIn_ReturnNotFound(int? id)
        {
            // Arrange
            repository.Setup(r => r.GetMemberAsync(3)).ReturnsAsync(member);

            // Act
            var result = await controller.Details(id);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Edit_WhenCalled_ReturnMember()
        {
            // Arrange               
            repository.Setup(r => r.GetMemberAsync(3)).ReturnsAsync(member);

            // Act
            var result = await controller.Edit(3) as ViewResult;
            var model = result.Model as MemberEditViewModel;

            // Assert 
            Assert.That(result, Is.Not.Null);
            Assert.That(model.Id, Is.EqualTo(3));
        }

        [Test]
        public async Task Edit_WhenCalled_UpdateMemberAndRedirectToIndex()
        {
            // Arrange               
            repository.Setup(r => r.GetMemberAsync(3)).ReturnsAsync(member);

            var model = new MemberEditViewModel
            {
                Id = 3,
                FirstName = "Sky",
                LastName = "B",
                Phone = "000 2456 7890",              
                Email = "skyb@domain.com"              
            };
            
            // Act            
            var result = await controller.Edit(model) as RedirectToActionResult;

            // Assert 
            repository.Verify(r => r.Update(member), Times.Once);
            Assert.That(result.ActionName, Is.EqualTo("index").IgnoreCase);            
        }
    }
}
