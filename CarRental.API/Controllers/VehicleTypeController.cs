﻿using AutoMapper;
using CarRental.API.Concrete;
using CarRental.Domain.DTOs.VehicleType;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : BaseController<VehicleType, CreateVehicleTypeDto, VehicleType>
    {
        public VehicleTypeController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }
}
