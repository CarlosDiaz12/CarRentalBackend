using AutoMapper;
using CarRental.API.Concrete;
using CarRental.Domain.DTOs.FuelType;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelTypeController : BaseController<FuelType, CreateFuelTypeDto, FuelType>
    {
        public FuelTypeController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }
}
