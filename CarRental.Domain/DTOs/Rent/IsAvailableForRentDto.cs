using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.DTOs.Rent
{
    public class IsAvailableForRentDto
    {
        public int VehicleId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
