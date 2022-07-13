using AutoMapper;
using CarRental.API.Concrete;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<Employee, Employee>
    {
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }
}
