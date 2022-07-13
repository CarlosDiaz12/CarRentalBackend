using AutoMapper;
using CarRental.API.Concrete;
using CarRental.API.DTOs;
using CarRental.Domain.DTOs;
using CarRental.Domain.DTOs.Inspection;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionController : BaseController<Inspection, CreateInspectionDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public InspectionController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) => _unitOfWork = unitOfWork;

        [HttpGet("inspected")]
        public async Task<IActionResult> CheckVehicleIsInspected([FromQuery] CheckVehicleAvailabilityDto data)
        {
            var response = await _unitOfWork.InspectionRepository.VehicleIsInspected(data.VehicleId, data.ClientId, data.InspectionDate, data.Type);
            return Ok(new ResponseDto<bool>(response));
        }
    }
}
