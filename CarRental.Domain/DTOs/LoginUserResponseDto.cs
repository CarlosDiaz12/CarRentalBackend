using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.DTOs
{
    public class LoginUserResponseDto
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}
