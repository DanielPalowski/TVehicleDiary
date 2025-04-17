using VehicleDiary.Core.Interfaces.Services;

namespace VehicleDiary.Application.DTOs
{
    public class PetrolDto
    {
        public Guid Id { get; set; }
        public string PetrolDate { get; set; }
        public string PetrolType { get; set; }
        public int? PetrolMileage { get; set; }
        public int PetrolPrice { get; set; }
        public int PetrolAmount { get; set; }
        public Guid vehicleId { get; set; }
    }
}
