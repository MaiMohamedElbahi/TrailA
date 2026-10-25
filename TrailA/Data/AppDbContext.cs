using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using TrailA.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;

namespace TrailA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerProfile> CustomersProfiles { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<AppointmentService> AppointmentServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppointmentService>().HasKey(e=> new {e.ServiceId, e.AppointmentId});

            modelBuilder.Entity<Customer>().HasOne(e => e.CustomerProfile).WithOne(e => e.Customer)
                .HasForeignKey<CustomerProfile>(e => e.CustomerId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Customer>().HasMany(e => e.Vehicles).WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomeId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Vehicle>().HasMany(e => e.Appointments).WithOne(e => e.Vehicle)
                .HasForeignKey(e => e.VehicleId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Mechanic>().HasMany(e => e.Appointments).WithOne(e => e.Mechanic)
                .HasForeignKey(e => e.MechanicId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Appointment>().HasMany(e => e.AppointmentServices).WithOne(e => e.Appointment)
                .HasForeignKey(e=>e.AppointmentId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Service>().HasMany(e => e.AppointmentServices).WithOne(e=>e.Service)
                .HasForeignKey(e => e.ServiceId).OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Vehicle>().HasIndex(e => e.PlateNumer).IsUnique();
            modelBuilder.Entity<Appointment>().Property(e => e.Status).HasDefaultValue("Pending");

            modelBuilder.Entity<Customer>().HasData(
               new Customer { Id = 1 , FullName =  "Ahmed Hassan" , Email=   "ahmed.hassan@example.com", Phone=  "01012345678", Address= "12 Nile Street, Giza" },
               new Customer { Id = 2 , FullName = "Mona Ali", Email= "mona.ali@example.com", Phone= "01023456789", Address= "25 Tahrir Street, Cairo" },
               new Customer { Id = 3 , FullName = "Omar Samir", Email= "omar.samir @example.com", Phone= "01034567890", Address= "8 El - Nasr Street, Giza" }
                );


            modelBuilder.Entity<CustomerProfile>().HasData(
                new CustomerProfile { Id = 1 , PreferredContactMethod = "Phone", DateTime = new DateTime(1995, 4, 12), CustomerId = 1 },
                new CustomerProfile { Id = 2 , PreferredContactMethod ="Email", DateTime = new DateTime(1998, 9, 23), CustomerId = 2 },
                new CustomerProfile { Id = 3 , PreferredContactMethod = "Phone", DateTime = new DateTime(1992, 1, 30), CustomerId = 3 }
                );

            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle {  Id = 1, Make= "Toyota", Model= "Corolla", Year = 2022, PlateNumer = "GIZ-1234", Mileage=45000, CustomeId = 1},
                new Vehicle {  Id = 2, Make= "Hyundai", Model= "Elantra", Year = 2021, PlateNumer = "CAI-5678", Mileage=62000, CustomeId = 2},
                new Vehicle {  Id = 3, Make= "Kia", Model= "Sportage", Year = 2024, PlateNumer = "GIZ-9012", Mileage=12000, CustomeId = 3},
                new Vehicle {  Id = 4, Make= "Kia", Model= "Sportage", Year = 2024, PlateNumer = "GIZ-9112", Mileage=12000, CustomeId = 3}
                );

            modelBuilder.Entity<Mechanic>().HasData(
                new Mechanic { Id = 1, FullName = "Karim Mostafa", Specialization= "Engine Repair", Phone= "01112345678", HireDate = new DateTime(2010, 3, 15)},
                new Mechanic { Id = 2, FullName = "Salma Ibrahim", Specialization= "Electrical Systems", Phone= "01123456789", HireDate = new DateTime(2021, 7, 1)},
                new Mechanic { Id = 3, FullName = "Youssef Adel", Specialization= "General Maintenance", Phone= "01134567890", HireDate = new DateTime(2019, 11, 20)},
                new Mechanic { Id = 4, FullName = "Youssef Adel", Specialization= "General Maintenance", Phone= "01134567890", HireDate = new DateTime(2019, 11, 20)}
            );

            modelBuilder.Entity<Service>().HasData(

                new Service { Id = 1, Name="Oil Change", Description="Engine oil and oil filter replacement", Price =800, EstimatedDuration =30},
                new Service { Id = 2, Name="Brake Inspection", Description="Inspect brake pads, discs, and fluid", Price =500, EstimatedDuration =45},
                new Service { Id = 3, Name="Battery Replacement", Description="Test and replace the vehicle battery", Price =2200, EstimatedDuration =40},
                new Service { Id = 4, Name="Battery Replacement", Description="Test and replace the vehicle battery", Price =2200, EstimatedDuration =40},
                new Service { Id = 5, Name="Battery Replacement", Description="Test and replace the vehicle battery", Price =2200, EstimatedDuration =40}
                );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, AppointmentDate = new DateTime(2026, 10, 20), Status = "Completed", Notes = "Oil changed; vehicle checked", ActualPrice =800 , MechanicId=1, VehicleId=1},
                new Appointment { Id = 2, AppointmentDate = new DateTime(2026, 10, 22), Status = "Pending", Notes ="Customer reported a warning light", ActualPrice = 0, MechanicId=2, VehicleId=2},
                new Appointment { Id = 3, AppointmentDate = new DateTime(2026, 10, 25), Status = "Canceled", Notes ="Customer requested cancellation", ActualPrice = 0, MechanicId=3, VehicleId=3},
                new Appointment { Id = 4, AppointmentDate = new DateTime(2026, 10, 25), Status = "Canceled", Notes ="Customer requested cancellation", ActualPrice = 0, MechanicId=4, VehicleId=4}
                );
            modelBuilder.Entity<AppointmentService>().HasData(
                new AppointmentService { AppointmentId = 1 , ServiceId = 1 },
                new AppointmentService { AppointmentId = 2 , ServiceId = 2 },
                new AppointmentService { AppointmentId = 3 , ServiceId = 3 },
                new AppointmentService { AppointmentId = 4 , ServiceId = 4 }
                );
        }

    }
}
