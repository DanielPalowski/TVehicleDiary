using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Mappings
{
    public class RepairVehicleProfile : Profile
    {
        public RepairVehicleProfile() 
        {
            CreateMap<DBRepairVehicleModel, RepairVehicleDto>();
            CreateMap<RepairVehicleDto, DBRepairVehicleModel>();
            CreateMap<DBRepairVehicleModelVM, RepairVehicleDto>();
            CreateMap<RepairVehicleDto, DBRepairVehicleModelVM>();
        }
    }
}

