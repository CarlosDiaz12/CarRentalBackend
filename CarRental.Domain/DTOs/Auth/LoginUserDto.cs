using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.DTOs.Auth
{
    public class LoginUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
