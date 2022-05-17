﻿using CarRental.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Domain.Interfaces
{
    public interface IAuthRepository: IRepository<User>
    {
        Task<User> Login(string userName, string password);
    }
}
