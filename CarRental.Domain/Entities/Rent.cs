using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.Entities
{
    public class Rent: BaseEntity
    {
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Returned { get; set; }
        public decimal RatePerDay { get; set; }
        public int DaysQuantity { get; set; }
        public string Comment { get; set; }
    }
}
