using System.ComponentModel.DataAnnotations;
using VehicleDiary.Core.Entities;

namespace VehicleDiary.Application.DTOs
{
    public class RepairDto
    {

        public string RepairType { get; set; }

        public string? RepairDescription { get; set; }

        public int RepairCost { get; set; }

        public string RepairMade { get; set; }

        public int RepairMileage { get; set; }

        public Guid vehicleId { get; set; }

    }
}
