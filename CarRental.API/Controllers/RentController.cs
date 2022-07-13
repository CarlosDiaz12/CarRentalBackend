using AutoMapper;
using CarRental.API.Concrete;
using CarRental.API.DTOs;
using CarRental.Domain.DTOs.Rent;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : BaseController<Rent, CreateRentDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        public RentController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) => _unitOfWork = unitOfWork;

        [HttpGet("available")]
        public async Task<IActionResult> IsAvailableForRent([FromQuery] IsAvailableForRentDto dto)
        {
            var result = await _unitOfWork.RentRepository.IsAvailableForRent(dto.VehicleId, dto.RentDate, dto.ReturnDate);
            return Ok(new ResponseDto<bool>(result));
        }

        [HttpPut("{rentId}/complete")]
        public async Task<IActionResult> CompleteRent([FromRoute] int rentId)
        {
            await _unitOfWork.RentRepository.CompleteRent(rentId);
            var result = (await _unitOfWork.SaveChangesAsync()) > 0;
            return Ok(new ResponseDto<bool>(result, result));
        }
    }
}
