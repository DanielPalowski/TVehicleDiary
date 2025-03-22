﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using VehicleDiary.Interfaces;

namespace VehicleDiary.Models
{
    public class DBRepairsModel : IVehicleEntity
    {
        public int Id { get; set; }
        [Required]
        public string RepairType { get; set; }
        public string? RepairDescription { get; set; }
        [Required]
        public int RepairCost {  get; set; }
        [Required]
        public string RepairMade { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public int RepairMileage { get; set; }
        [Required]
        public int VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public DBVehicleModel Vehicle {  get; set; }

    }
}
