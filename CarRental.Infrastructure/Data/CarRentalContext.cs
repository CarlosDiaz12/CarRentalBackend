using CarRental.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Infrastructure.Data
{
    public class CarRentalContext: DbContext
    {
        public IConfiguration Configuration { get; }
        public CarRentalContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            optionsBuilder
                .UseSqlServer(Configuration.GetConnectionString("CarRentalDB"))
                .UseLazyLoadingProxies(); // ACTIVATE LAZY LOADING ALWAYS
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(x => x.IdentificationCard).IsUnique();
                entity.Property(x => x.TaxPayerType)
                       .HasConversion<string>();
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(x => x.IDCard).IsUnique();
                entity.Property(x => x.WorkShift)
                       .HasConversion<string>();
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasIndex(x => x.Description).IsUnique();
            });

            modelBuilder.Entity<FuelType>(entity =>
            {
                entity.HasIndex(x => x.Description).IsUnique();
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasIndex(x => x.Description).IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(x => x.UserName).IsUnique();
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasIndex(x => new { x.ChassisNumber }).IsUnique();
                entity.HasIndex(x => new { x.PlateNumber }).IsUnique();
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.HasIndex(x => x.Description).IsUnique();
            });

            modelBuilder.Entity<Inspection>(entity =>
            {
                entity.Property(x => x.InspectionType)
                       .HasConversion<string>();
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasOne(x => x.Model)
                       .WithMany()
                       .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}
