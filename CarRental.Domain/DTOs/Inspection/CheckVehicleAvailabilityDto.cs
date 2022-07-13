using CarRental.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Domain.DTOs.Inspection
{
    public class CheckVehicleAvailabilityDto
    {
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public DateTime InspectionDate { get; set; }
        public InspectionType Type { get; set; }
    }
}
