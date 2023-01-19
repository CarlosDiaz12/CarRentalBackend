using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.DTOs.Brand
{
    public class CreateBrandDto
    {
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
