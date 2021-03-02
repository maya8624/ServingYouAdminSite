using Microsoft.EntityFrameworkCore;
using ServingYouAdmin.Enums;
using ServingYouAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    OrderDate = Convert.ToDateTime("05/12/2020"),
                    OrderStatus = OrderStatus.Progress,
                    OrderTotal = 56.00m,                    
                    EmployeeId = 1,
                    OrderMethod = OrderMethods.Web,
                    CustomerId = 1,
                },
                new Order
                {
                    Id = 2,
                    OrderDate = Convert.ToDateTime("05/12/2020"),
                    OrderStatus = OrderStatus.Completed,
                    OrderTotal = 41.00m,                    
                    EmployeeId = 1,
                    OrderMethod = OrderMethods.Web,
                    CustomerId = 3,
                },
                new Order
                {
                    Id = 3,
                    OrderDate = Convert.ToDateTime("05/12/2020"),
                    OrderStatus = OrderStatus.Progress,
                    OrderTotal = 50.00m,                    
                    EmployeeId = 1,
                    OrderMethod = OrderMethods.Mobile,
                    CustomerId = 2,
                }
            );

            modelBuilder.Entity<OrderMenu>().HasData(
                 new OrderMenu
                 {
                     Id = 5,
                     OrderId = 1,
                     MenuId = 1,
                     Quantity = 2,
                     Price = 18.00m,
                     DateCreated = Convert.ToDateTime("05/12/2020"),
                 },
                new OrderMenu
                {
                    Id = 6,
                    OrderId = 1,
                    MenuId = 3,
                    Quantity = 1,
                    Price = 20.00m,
                    DateCreated = Convert.ToDateTime("05/12/2020"),
                },
                new OrderMenu
                {
                      Id = 1,
                      OrderId = 2,
                      MenuId = 3,
                      Quantity = 1,
                      Price = 20.00m,
                      DateCreated = Convert.ToDateTime("05/12/2020"),
                },
                new OrderMenu
                {
                    Id = 2,
                    OrderId = 2,
                    MenuId = 5,
                    Quantity = 1,
                    Price = 21.00m,
                    DateCreated = Convert.ToDateTime("05/12/2020"),
                },
                new OrderMenu
                {
                    Id = 3,
                    OrderId = 3,
                    MenuId = 12,
                    Quantity = 1,
                    Price = 25.00m,
                    DateCreated = Convert.ToDateTime("05/12/2020"),                
                },
                new OrderMenu
                {
                    Id = 4,
                    OrderId = 3,
                    MenuId = 2,
                    Quantity = 1,
                    Price = 25.00m,
                    DateCreated = Convert.ToDateTime("05/12/2020"),
                }
            );
            modelBuilder.Entity<Restaurant>().HasData(
                new Restaurant
                {
                    Id = 1,
                    Name = "Serving You",                    
                    Phone = "02 1234 5678",
                    Email = "servingyou@domain.com",
                    Description = "nice restaurant",                    
                    Postcode = "2000",
                    StateCode = "NSW",
                    Unit = "Unit 100",
                    Street = "Harbour Bridge",
                    Town = "Sydney",
                    DateCreated = Convert.ToDateTime("20/11/2018")
                }
            );
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    FirstName = "Andy",
                    LastName = "Jung",
                    Phone = "0422230861",
                    Email = "andyj@domain.com",
                    Position = Position.Boss,
                    JobType = JobType.Fulltime,
                    Postcode = "2126",
                    StateCode = "NSW",
                    Unit = "Unit 4",
                    Street = "182 Boundary Rd",
                    Town = "Cherrybrook",
                    DateCreated = Convert.ToDateTime("2/12/2020")
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Lina",
                    LastName = "Jung",
                    Phone = "0422230861",
                    Email = "linaj@domain.com",
                    Position = Position.Manager,
                    JobType = JobType.Fulltime,
                    Postcode = "2126",
                    StateCode = "NSW",
                    Unit = "Unit 4",
                    Street = "182 Boundary Rd",
                    Town = "Cherrybrook",
                    DateCreated = Convert.ToDateTime("2/12/2020")
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Sam",
                    LastName = "Monday",
                    Phone = "0422230861",
                    Email = "samm@domain.com",
                    Position = Position.Waiter,
                    JobType = JobType.Parttime,
                    Postcode = "2154",
                    StateCode = "NSW",
                    Unit = "",
                    Street = "22 Castle Towers",
                    Town = "Casle Hill",
                    DateCreated = Convert.ToDateTime("4/12/2020")
                }
            );

            modelBuilder.Entity<Customer>().HasData(
                new Customer 
                { 
                    Id = 1,
                    FirstName = "Andy", 
                    LastName = "Jung",
                    Phone = "0422230861",
                    Email = "andyj@domain.com",
                    Password = "12345",
                    DateRegistered = Convert.ToDateTime("2/12/2020")
                },
                new Customer
                {
                    Id = 2,
                    FirstName = "Sam",
                    LastName = "Queen",
                    Phone = "0000000000",
                    Email = "samq@domain.com",
                    Password = "12345",
                    DateRegistered = Convert.ToDateTime("1/12/2020")
                },
                new Customer
                {
                    Id = 3,
                    FirstName = "Joseph",
                    LastName = "King",
                    Phone = "0234567891",
                    Email = "josephk@domain.com",
                    Password = "12345",
                    DateRegistered = Convert.ToDateTime("4/12/2020")
                }
            );

            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    Id = 1,
                    FirstName = "Andy",
                    LastName = "Jung",
                    Mobile = "0422230861",
                    DateBooked = Convert.ToDateTime("21/12/2020"),
                    TimeBooked = "12:30",
                    Status = 1,
                    Method = 1,
                    NumberinParty = 5,
                    DateCreated = Convert.ToDateTime("01/12/2020"),
                    TableNo = 1,
                    EmployeeId = 1
                },
                new Booking
                {
                    Id = 2,
                    FirstName = "Mary",
                    LastName = "Winter",
                    Mobile = "123456789",
                    DateBooked = Convert.ToDateTime("01/12/2020"),
                    TimeBooked = "17:30",
                    Status = 2,
                    Method = 2,
                    NumberinParty = 2,
                    DateCreated = Convert.ToDateTime("01/11/2020"),
                    TableNo = 2,
                    EmployeeId = 1
                },
                new Booking
                {
                    Id = 3,
                    FirstName = "Joseph",
                    LastName = "Summer",
                    Mobile = "00000000000",
                    DateBooked = Convert.ToDateTime("25/12/2020"),
                    TimeBooked = "18:30",
                    Status = 1,
                    Method = 1,
                    NumberinParty = 10,
                    DateCreated = Convert.ToDateTime("01/12/2020"),
                    TableNo = 3,
                    EmployeeId = 1
                }
            );
        }
    }
}
