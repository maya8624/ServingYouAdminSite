﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServingYouAdmin.Data;

namespace ServingYouAdmin.Migrations
{
    [DbContext(typeof(ServingYouContext))]
    [Migration("20201216023530_RemoveRelationshiRestaurantAndState")]
    partial class RemoveRelationshiRestaurantAndState
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("ServingYouAdmin.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateBooked")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Method")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("NumberinParty")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TableNo")
                        .HasColumnType("int");

                    b.Property<string>("TimeBooked")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Booking");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateBooked = new DateTime(2020, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            FirstName = "Andy",
                            LastName = "Jung",
                            Method = 1,
                            Mobile = "0422230861",
                            NumberinParty = 5,
                            Status = 1,
                            TableNo = 1,
                            TimeBooked = "12:30"
                        },
                        new
                        {
                            Id = 2,
                            DateBooked = new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            FirstName = "Mary",
                            LastName = "Winter",
                            Method = 2,
                            Mobile = "123456789",
                            NumberinParty = 2,
                            Status = 2,
                            TableNo = 2,
                            TimeBooked = "17:30"
                        },
                        new
                        {
                            Id = 3,
                            DateBooked = new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateCreated = new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            FirstName = "Joseph",
                            LastName = "Summer",
                            Method = 1,
                            Mobile = "00000000000",
                            NumberinParty = 10,
                            Status = 1,
                            TableNo = 3,
                            TimeBooked = "18:30"
                        });
                });

            modelBuilder.Entity("ServingYouAdmin.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistered = new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "andyj@domain.com",
                            FirstName = "Andy",
                            IsDeleted = false,
                            LastName = "Jung",
                            Password = "12345",
                            Phone = "0422230861"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistered = new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "samq@domain.com",
                            FirstName = "Sam",
                            IsDeleted = false,
                            LastName = "Queen",
                            Password = "12345",
                            Phone = "0000000000"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistered = new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "josephk@domain.com",
                            FirstName = "Joseph",
                            IsDeleted = false,
                            LastName = "King",
                            Password = "12345",
                            Phone = "0234567891"
                        });
                });

            modelBuilder.Entity("ServingYouAdmin.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("JobType")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("Position")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "andyj@domain.com",
                            FirstName = "Andy",
                            IsDeleted = false,
                            JobType = 0,
                            LastName = "Jung",
                            Phone = "0422230861",
                            Position = 2,
                            Postcode = "2126",
                            State = 1,
                            Street = "182 Boundary Rd",
                            Town = "Cherrybrook",
                            Unit = "Unit 4"
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2020, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "linaj@domain.com",
                            FirstName = "Lina",
                            IsDeleted = false,
                            JobType = 0,
                            LastName = "Jung",
                            Phone = "0422230861",
                            Position = 1,
                            Postcode = "2126",
                            State = 1,
                            Street = "182 Boundary Rd",
                            Town = "Cherrybrook",
                            Unit = "Unit 4"
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(2020, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "samm@domain.com",
                            FirstName = "Sam",
                            IsDeleted = false,
                            JobType = 1,
                            LastName = "Monday",
                            Phone = "0422230861",
                            Position = 0,
                            Postcode = "2154",
                            State = 1,
                            Street = "22 Castle Towers",
                            Town = "Casle Hill",
                            Unit = ""
                        });
                });

            modelBuilder.Entity("ServingYouAdmin.Models.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Available")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("ServingYouAdmin.Models.MenuPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("MenuPrice");
                });

            modelBuilder.Entity("ServingYouAdmin.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderMethod")
                        .HasColumnType("int");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderMethod = 0,
                            OrderStatus = 0,
                            OrderTotal = 56.00m
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 3,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderMethod = 0,
                            OrderStatus = 2,
                            OrderTotal = 41.00m
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 2,
                            EmployeeId = 1,
                            OrderDate = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            OrderMethod = 1,
                            OrderStatus = 0,
                            OrderTotal = 50.00m
                        });
                });

            modelBuilder.Entity("ServingYouAdmin.Models.OrderMenu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("MenuId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderMenu");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            DateCreated = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = 1,
                            OrderId = 1,
                            Price = 18.00m,
                            Quantity = 2
                        },
                        new
                        {
                            Id = 6,
                            DateCreated = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = 3,
                            OrderId = 1,
                            Price = 20.00m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = 3,
                            OrderId = 2,
                            Price = 20.00m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = 5,
                            OrderId = 2,
                            Price = 21.00m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = 12,
                            OrderId = 3,
                            Price = 25.00m,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 4,
                            DateCreated = new DateTime(2020, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            MenuId = 2,
                            OrderId = 3,
                            Price = 25.00m,
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("ServingYouAdmin.Models.Restaurant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Town")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Unit")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Restaurant");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(2018, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateUpdated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "nice restaurant",
                            Email = "servingyou@domain.com",
                            Name = "Serving You",
                            Phone = "02 1234 5678",
                            Postcode = "2000",
                            StateCode = "NSW",
                            Street = "Harbour Bridge",
                            Town = "Sydney",
                            Unit = "Unit 100"
                        });
                });

            modelBuilder.Entity("ServingYouAdmin.Models.State", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("State");
                });

            modelBuilder.Entity("ServingYouAdmin.Models.Order", b =>
                {
                    b.HasOne("ServingYouAdmin.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ServingYouAdmin.Models.OrderMenu", b =>
                {
                    b.HasOne("ServingYouAdmin.Models.Menu", "Menu")
                        .WithMany("OrderMenu")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ServingYouAdmin.Models.Order", "Order")
                        .WithMany("OrderMenu")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("ServingYouAdmin.Models.Menu", b =>
                {
                    b.Navigation("OrderMenu");
                });

            modelBuilder.Entity("ServingYouAdmin.Models.Order", b =>
                {
                    b.Navigation("OrderMenu");
                });
#pragma warning restore 612, 618
        }
    }
}
