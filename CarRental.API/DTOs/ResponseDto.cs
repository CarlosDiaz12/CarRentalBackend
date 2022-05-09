﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRental.API.DTOs
{
    public class ResponseDto<T>
    {
        public ResponseDto(T data)
        {
            Data = data;
        }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; } = true;
        public T Data { get; set; }
    }
}
