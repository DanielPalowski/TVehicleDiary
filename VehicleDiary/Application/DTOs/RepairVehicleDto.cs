namespace VehicleDiary.Application.DTOs
{
    public class RepairVehicleDto
    {
        public Guid Id { get; set; }
        public string RepairVCategory { get; set; }
        public string RepairVType { get; set; }
        public string RepairVName { get; set; }
        public string RepairVPart { get; set; }
        public DateTime RepairVWhen { get; set; }
        public float RepairVPrice { get; set; }
        public string ReapairVNotes { get; set; }
        public string RepairVTechnician { get; set; }
        public Guid VehicleId { get; set; }
    }
}
