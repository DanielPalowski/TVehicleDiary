namespace VehicleDiary.Application.DTOs
{
    public class UpgradeVehicleDto
    {
        public Guid Id { get; set; }
        public string UpgradeVCategory { get; set; }
        public string UpgradeVType { get; set; }
        public string UpgradeVName { get; set; }
        public string UpgradeVStatus { get; set; }
        public DateTime UpgradeVWhen { get; set; }
        public float UpgradeVPrice { get; set; }
        public int UpgradeVMileage { get; set; }
        public string UpgradeVNotes { get; set; }
        public string UpgradeVTechnician { get; set; }
        public string UpgradeVPartBrand { get; set; }

        public string UpgradeVPartCode { get; set; }

        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public IFormFile Upload { get; set; }
        public Guid VehicleId { get; set; }
    }
}
