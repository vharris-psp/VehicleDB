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
    [DbContext(typeof(AppDbContext))]
    [Migration("20240209011159_InitialCreate1")]
    partial class InitialCreate1
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

                    b.Property<DateTime>("DOB")
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

            modelBuilder.Entity("PersonVehicle", b =>
                {
                    b.Property<int>("PersonsId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VehiclesVIN")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonsId", "VehiclesVIN");

                    b.HasIndex("VehiclesVIN");

                    b.ToTable("PersonVehicle");
                });

            modelBuilder.Entity("Trip", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArrivalAddressId")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("ArrivalTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartureAddressId")
                        .HasColumnType("INTEGER");

                    b.Property<TimeSpan>("DepartureTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("DriverID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReasonForTrip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("ReturnArrivalTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan?>("ReturnDepartureTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("VehicleVIN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ArrivalAddressId");

                    b.HasIndex("DepartureAddressId");

                    b.HasIndex("VehicleVIN");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<string>("VIN")
                        .HasMaxLength(17)
                        .HasColumnType("TEXT");

                    b.Property<int>("EndingCondition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("EndingMileage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FuelLevel")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReasonForTrip")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StartingCondition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StartingMileage")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("VIN");

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

            modelBuilder.Entity("PersonVehicle", b =>
                {
                    b.HasOne("Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehiclesVIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Trip", b =>
                {
                    b.HasOne("Address", "ArrivalAddress")
                        .WithMany("ArrivalTrips")
                        .HasForeignKey("ArrivalAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Address", "DepartureAddress")
                        .WithMany("DepartureTrips")
                        .HasForeignKey("DepartureAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Person", "Driver")
                        .WithMany("DrivenTrips")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicle", "Vehicle")
                        .WithMany("Trips")
                        .HasForeignKey("VehicleVIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArrivalAddress");

                    b.Navigation("DepartureAddress");

                    b.Navigation("Driver");

                    b.Navigation("Vehicle");
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

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
