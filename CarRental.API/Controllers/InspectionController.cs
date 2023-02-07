using CarRental.API.Concrete;
using CarRental.API.DTOs;
using CarRental.Domain.DTOs;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionController : BaseController<Inspection>
    {
        private readonly IUnitOfWork _unitOfWork;
        public InspectionController(IUnitOfWork unitOfWork) : base(unitOfWork) => _unitOfWork = unitOfWork;

        [HttpGet("inspected")]
        public async Task<IActionResult> CheckVehicleIsInspected([FromQuery] CheckVehicleAvaiabilityDto data)
        {
            var response = await _unitOfWork.InspectionRepository.VehicleIsInspected(data.vehicleId, data.clientId, data.inspectionDate);
            return Ok(new ResponseDto<bool>(response));
        }
    }
}
