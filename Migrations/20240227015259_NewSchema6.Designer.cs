﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleDB;

#nullable disable

namespace VehicleDB.Migrations
{
    [DbContext(typeof(VehicleDbContext))]
    [Migration("20240227015259_NewSchema6")]
    partial class NewSchema6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Issue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Severity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("PersonTrip", b =>
                {
                    b.Property<int>("PassengerTripsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PassengersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PassengerTripsId", "PassengersId");

                    b.HasIndex("PassengersId");

                    b.ToTable("TripPassenger", (string)null);
                });

            modelBuilder.Entity("RentalLocation", b =>
                {
                    b.Property<int>("StoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("StoreAddressId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StoreID");

                    b.HasIndex("StoreAddressId");

                    b.ToTable("RentalLocation");
                });

            modelBuilder.Entity("Trip", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddressId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AddressId1")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("ArrivalTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("DepartureTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("DriverID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DropOffLocationStoreID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PickupLocationStoreID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReasonForTrip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("ReturnArrivalTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReturnDate")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("ReturnDepartureTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("VehicleVIN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AddressId1");

                    b.HasIndex("DropOffLocationStoreID");

                    b.HasIndex("PickupLocationStoreID");

                    b.HasIndex("VehicleVIN");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<string>("VIN")
                        .HasMaxLength(17)
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentCondition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentFuelLevel")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentMileage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RentalLocationStoreID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("VIN");

                    b.HasIndex("RentalLocationStoreID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("PersonTrip", b =>
                {
                    b.HasOne("Trip", null)
                        .WithMany()
                        .HasForeignKey("PassengerTripsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Person", null)
                        .WithMany()
                        .HasForeignKey("PassengersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RentalLocation", b =>
                {
                    b.HasOne("Address", "StoreAddress")
                        .WithMany()
                        .HasForeignKey("StoreAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StoreAddress");
                });

            modelBuilder.Entity("Trip", b =>
                {
                    b.HasOne("Address", null)
                        .WithMany("ArrivalTrips")
                        .HasForeignKey("AddressId");

                    b.HasOne("Address", null)
                        .WithMany("DepartureTrips")
                        .HasForeignKey("AddressId1");

                    b.HasOne("RentalLocation", "DropOffLocation")
                        .WithMany()
                        .HasForeignKey("DropOffLocationStoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Person", "Driver")
                        .WithMany("DrivenTrips")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentalLocation", "PickupLocation")
                        .WithMany()
                        .HasForeignKey("PickupLocationStoreID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicle", "Vehicle")
                        .WithMany("Trips")
                        .HasForeignKey("VehicleVIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("DropOffLocation");

                    b.Navigation("PickupLocation");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.HasOne("RentalLocation", null)
                        .WithMany("VehiclesInInventory")
                        .HasForeignKey("RentalLocationStoreID");
                });

            modelBuilder.Entity("Address", b =>
                {
                    b.Navigation("ArrivalTrips");

                    b.Navigation("DepartureTrips");
                });

            modelBuilder.Entity("Person", b =>
                {
                    b.Navigation("DrivenTrips");
                });

            modelBuilder.Entity("RentalLocation", b =>
                {
                    b.Navigation("VehiclesInInventory");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
