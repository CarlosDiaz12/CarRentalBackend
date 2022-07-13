namespace CarRental.Domain.DTOs.Model
{
    public class CreateModelDto
    {
        public string Description { get; set; }
        public int BrandId { get; set; }
        public bool Status { get; set; }
    }
}
