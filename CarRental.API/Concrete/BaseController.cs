using AutoMapper;
using CarRental.API.Abstract;
using CarRental.API.DTOs;
using CarRental.Domain.DTOs;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.API.Concrete
{
    [Produces("application/json")]
    [ApiController]
    public abstract class BaseController<T, TCreateDto, TUpdateDto> : ControllerBase, IBaseController<T, TCreateDto, TUpdateDto> where T: BaseEntity where TUpdateDto : BaseEntity // cambiarse por BaseUpdateDto
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BaseController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<T>();
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TCreateDto _object)
        {
            var newObject = _mapper.Map<T>(_object);

            await _repository.Insert(newObject);
            await _unitOfWork.SaveChangesAsync();

            var response = new ResponseDto<bool>(true);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            await _repository.Delete(Id);
            await _unitOfWork.SaveChangesAsync();
            var response = new ResponseDto<bool>(true);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var data = await _repository.GetById(Id);
            var response = new ResponseDto<T>(null);
            if(data == null)
            {
                response.Success = false;
                response.ErrorMessage = "Recurso no encontrado.";
                return NotFound(response);
            }

            response.Data = data;
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _repository.GetAll();
            await _unitOfWork.SaveChangesAsync();
            return Ok(new ResponseDto<IEnumerable<T>>(data));
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TUpdateDto _object)
        {
            var exists = await _repository.Exists(_object.Id);
            var response = new ResponseDto<bool>(true);

            if (exists == false)
            {
                response.Success = false;
                response.ErrorMessage = "Recurso no encontrado.";
                return NotFound(response);
            }
            var updateModel = _mapper.Map<T>(_object);

            _repository.Update(updateModel);
            await _unitOfWork.SaveChangesAsync();
            return Ok(response);
        }
    }
}
