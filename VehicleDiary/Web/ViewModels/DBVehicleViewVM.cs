namespace VehicleDiary.Web.ViewModels
{
    public class DBVehicleViewVM
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public string Model { get; set; }
        public int Power { get; set; }
        public int MadeYear { get; set; }
        public string? Insurence { get; set; }
        public string? VIN { get; set; }
        public string? License_plate { get; set; }
        public string? Description { get; set; }
        public float? RepairCost { get; set; }
        public DateTime? Bought { get; set; }
        
    }
}
