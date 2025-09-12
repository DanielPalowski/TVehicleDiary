namespace VehicleDiary.Application.DTOs
{
    public class RepairAttachmentDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public Guid RepairVehicleId { get; set; }
    }
}
