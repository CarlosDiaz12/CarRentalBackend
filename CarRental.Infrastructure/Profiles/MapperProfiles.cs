using AutoMapper;
using CarRental.Domain.DTOs.Brand;
using CarRental.Domain.DTOs.Client;
using CarRental.Domain.DTOs.Employee;
using CarRental.Domain.DTOs.FuelType;
using CarRental.Domain.DTOs.Inspection;
using CarRental.Domain.DTOs.Model;
using CarRental.Domain.DTOs.Rent;
using CarRental.Domain.DTOs.Vehicle;
using CarRental.Domain.Entities;

namespace CarRental.Infrastructure.Profiles
{
    public class MapperProfiles: Profile
    {
        public MapperProfiles()
        {
            // Brand
            CreateMap<CreateBrandDto, Brand>().ReverseMap();

            // Client
            CreateMap<CreateClientDto, Client>().ReverseMap();

            // Employee
            CreateMap<CreateEmployeeDto, Employee>().ReverseMap();

            // FuelType
            CreateMap<CreateFuelTypeDto, FuelType>().ReverseMap();

            // Inspection
            CreateMap<CreateInspectionDto, Inspection>().ReverseMap();

            // Model
            CreateMap<CreateModelDto, Model>().ReverseMap();

            // Rent 
            CreateMap<CreateRentDto, Rent>().ReverseMap();

            // Vehicle
            CreateMap<CreateVehicleDto, Vehicle>().ReverseMap();

            // VehicleType
            CreateMap<CreateVehicleDto, VehicleType>().ReverseMap();
        }
    }
}
