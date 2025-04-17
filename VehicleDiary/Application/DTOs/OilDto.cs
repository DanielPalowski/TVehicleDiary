namespace VehicleDiary.Application.DTOs
{
    public class OilDto
    {
        public Guid Id { get; set; }
        public float OilAmount { get; set; }
        public DateTime OilDate { get; set; }
        public string OilType { get; set; }
        public int OilMileage { get; set; }
        public float OilPrice { get; set; }
        public string? OilDescription { get; set; }
        public Guid VehicleId { get; set; }
    }
}
