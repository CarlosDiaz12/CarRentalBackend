namespace CarRental.Domain.DTOs.Vehicle
{
    public class CreateVehicleDto
    {
        public string Description { get; set; }
        public int ChassisNumber { get; set; }
        public int EngineNumber { get; set; }
        public int PlateNumber { get; set; }
        public int VehicleTypeId { get; set; }
        public int BrandId { get; set; }
        public int ModelId { get; set; }
        public int FuelTypeId { get; set; }
        public bool Status { get; set; }
    }
}
