using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.DTOs.FuelType
{
    public class CreateFuelTypeDto
    {
        public string Description { get; set; }
        public bool Status { get; set; }
    }
}
