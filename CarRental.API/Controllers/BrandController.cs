using AutoMapper;
using CarRental.API.Concrete;
using CarRental.Domain.DTOs.Brand;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : BaseController<Brand, CreateBrandDto>
    {
        public BrandController(IUnitOfWork unitOfWork, IMapper mapper): base(unitOfWork, mapper) { }
    }
}
