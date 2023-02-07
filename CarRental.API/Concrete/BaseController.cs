using CarRental.API.Abstract;
using CarRental.API.DTOs;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using CarRental.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRental.API.Concrete
{
    [Produces("application/json")]
    [ApiController]
    [Authorize]
    public abstract class BaseController<T> : ControllerBase, IBaseController<T> where T: BaseEntity
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public BaseController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.GetRepository<T>();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T _object)
        {
            await _repository.Insert(_object);
            var result = await _unitOfWork.SaveChangesAsync() > 0;
            var response = new ResponseDto<bool>(result, result);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.Delete(id);
            var result = await _unitOfWork.SaveChangesAsync() > 0;
            var response = new ResponseDto<bool>(result, result);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var data = await _repository.GetById(Id);
            await _unitOfWork.SaveChangesAsync();
            var response = new ResponseDto<T>(null);
            if(data == null)
            {
                response.Success = false;
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
        public async Task<IActionResult> Update([FromBody] T _object)
        {
            _repository.Update(_object);
            var result = await _unitOfWork.SaveChangesAsync() > 0;
            var response = new ResponseDto<bool>(result, result);
            return Ok(response);
        }
    }
}
