using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Mappings
{
    public class UpgradeVehicleProfile : Profile
    {
        public UpgradeVehicleProfile()
        {
            CreateMap<DBUpgradeVehicleModel, UpgradeVehicleDto>();
            CreateMap<UpgradeVehicleDto, DBUpgradeVehicleModel>();
            CreateMap<DBUpgradeVehicleModelVM, UpgradeVehicleDto>();
            CreateMap<UpgradeVehicleDto, DBUpgradeVehicleModelVM>();
        }
    }
}
