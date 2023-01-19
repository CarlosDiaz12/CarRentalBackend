using System;

namespace CarRental.Domain.DTOs.Rent
{
    public class CheckRentAvailabilityDto
    {
        public int IdVehicle { get; set; }
        public int IdClient { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
