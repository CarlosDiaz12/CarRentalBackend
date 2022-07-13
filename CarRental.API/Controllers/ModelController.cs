using AutoMapper;
using CarRental.API.Concrete;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : BaseController<Model, Model>
    {
        public ModelController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }
}
