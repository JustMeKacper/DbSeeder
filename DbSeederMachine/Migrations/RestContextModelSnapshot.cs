﻿// <auto-generated />
using System;
using DbSeederMachine.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbSeederMachine.Migrations
{
    [DbContext(typeof(RestContext))]
    partial class RestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DbSeederMachine.Data.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"));

                    b.Property<string>("CarBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Vin")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("DbSeederMachine.Data.DeliveryOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CarId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("ClientsRate")
                        .HasColumnType("int");

                    b.Property<int>("DeliveryManId")
                        .HasColumnType("int");

                    b.Property<string>("OrderContent")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrderState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SuggestedDeliveryTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("DeliveryManId");

                    b.ToTable("DeliveryOrders");
                });

            modelBuilder.Entity("DbSeederMachine.Data.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkPosition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("hSalary")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DbSeederMachine.Data.EmployeeTask", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskId"));

                    b.Property<string>("Duties")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Employees_id")
                        .HasColumnType("int");

                    b.Property<string>("Privileges")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaskId");

                    b.HasIndex("Employees_id");

                    b.ToTable("EmployeeTasks");
                });

            modelBuilder.Entity("DbSeederMachine.Data.GuestManagement", b =>
                {
                    b.Property<int>("GuestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GuestID"));

                    b.Property<int?>("DeliveryOrderID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int?>("LoyaltyCardID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("OrderID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ReservationID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("GuestID");

                    b.HasIndex("DeliveryOrderID");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("LoyaltyCardID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ReservationID");

                    b.ToTable("GuestManagements");
                });

            modelBuilder.Entity("DbSeederMachine.Data.LoyaltyCard", b =>
                {
                    b.Property<int>("CardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CardId"));

                    b.Property<float>("Discount")
                        .HasColumnType("real");

                    b.Property<string>("LastNameOfUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIP")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardId");

                    b.ToTable("LoyaltyCards");
                });

            modelBuilder.Entity("DbSeederMachine.Data.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderId"));

                    b.Property<int?>("IdLoyaltyCard")
                        .HasColumnType("int");

                    b.Property<string>("OrderDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("OrderId");

                    b.HasIndex("IdLoyaltyCard");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DbSeederMachine.Data.RentedCar", b =>
                {
                    b.Property<int>("idOfRent")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("idOfRent"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("CarState")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndOfRent")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartOfRent")
                        .HasColumnType("datetime2");

                    b.HasKey("idOfRent");

                    b.HasIndex("CarId");

                    b.HasIndex("DriverId");

                    b.ToTable("RentedCars");
                });

            modelBuilder.Entity("DbSeederMachine.Data.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"));

                    b.Property<int>("AmountOfPersons")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<bool>("Confirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DateOfReservation")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("DbSeederMachine.Data.RestaurantsTable", b =>
                {
                    b.Property<int>("TableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TableId"));

                    b.Property<bool>("IsNotBroken")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainEmployee")
                        .HasColumnType("int");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("TableId");

                    b.HasIndex("MainEmployee");

                    b.ToTable("RestaurantsTables");
                });

            modelBuilder.Entity("DbSeederMachine.Data.DeliveryOrder", b =>
                {
                    b.HasOne("DbSeederMachine.Data.Car", "Car")
                        .WithMany("DeliveryOrders")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbSeederMachine.Data.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("DeliveryManId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DbSeederMachine.Data.EmployeeTask", b =>
                {
                    b.HasOne("DbSeederMachine.Data.Employee", "Employee")
                        .WithMany("EmployeeTasks")
                        .HasForeignKey("Employees_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DbSeederMachine.Data.GuestManagement", b =>
                {
                    b.HasOne("DbSeederMachine.Data.DeliveryOrder", "DeliveryOrder")
                        .WithMany()
                        .HasForeignKey("DeliveryOrderID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DbSeederMachine.Data.Employee", null)
                        .WithMany("GuestManagements")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("DbSeederMachine.Data.LoyaltyCard", "LoyaltyCard")
                        .WithMany()
                        .HasForeignKey("LoyaltyCardID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DbSeederMachine.Data.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DbSeederMachine.Data.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DeliveryOrder");

                    b.Navigation("LoyaltyCard");

                    b.Navigation("Order");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("DbSeederMachine.Data.Order", b =>
                {
                    b.HasOne("DbSeederMachine.Data.LoyaltyCard", "LoyaltyCard")
                        .WithMany("Orders")
                        .HasForeignKey("IdLoyaltyCard");

                    b.Navigation("LoyaltyCard");
                });

            modelBuilder.Entity("DbSeederMachine.Data.RentedCar", b =>
                {
                    b.HasOne("DbSeederMachine.Data.Car", "Car")
                        .WithMany("RentedCars")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbSeederMachine.Data.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DbSeederMachine.Data.RestaurantsTable", b =>
                {
                    b.HasOne("DbSeederMachine.Data.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("MainEmployee")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DbSeederMachine.Data.Car", b =>
                {
                    b.Navigation("DeliveryOrders");

                    b.Navigation("RentedCars");
                });

            modelBuilder.Entity("DbSeederMachine.Data.Employee", b =>
                {
                    b.Navigation("EmployeeTasks");

                    b.Navigation("GuestManagements");
                });

            modelBuilder.Entity("DbSeederMachine.Data.LoyaltyCard", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
