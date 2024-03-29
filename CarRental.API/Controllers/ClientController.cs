﻿using AutoMapper;
using CarRental.API.Concrete;
using CarRental.Domain.DTOs.Client;
using CarRental.Domain.Entities;
using CarRental.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarRental.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController<Client, CreateClientDto, Client>
    {
        public ClientController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }
    }
}
