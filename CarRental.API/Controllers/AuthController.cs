using CarRental.API.DTOs;
using CarRental.Domain.DTOs.Auth;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
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
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            var result = await _unitOfWork.AuthRepository.Login(dto.UserName, dto.Password);
            var success = result != null;
            var response = new ResponseDto<User>(result, success);
            return Ok(response);
        }
    }
}
