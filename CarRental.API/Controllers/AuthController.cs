using CarRental.API.DTOs;
using CarRental.Domain.DTOs;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            try
            {
                var result = await _unitOfWork.AuthRepository.Login(dto.UserName, dto.Password);
                var response = new ResponseDto<LoginUserResponseDto>(result, true);
                return Ok(response);
            }
            catch (Exception ex)
            {
                var response = new ResponseDto<LoginUserResponseDto>(false, ex.Message);
                return BadRequest(response);
            }
        }
    }
}
