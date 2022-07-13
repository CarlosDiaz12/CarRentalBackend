using System;

namespace CarRental.Domain.DTOs.Rent
{
    public class CreateRentDto
    {
        public int EmployeeId { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Returned { get; set; }
        public decimal RatePerDay { get; set; }
        public int DaysQuantity { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
    }
}
