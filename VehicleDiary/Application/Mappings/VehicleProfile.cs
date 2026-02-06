using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Web.Controllers;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Mappings
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            //Vehicle
            CreateMap<DBVehicleModel, VehicleDto>();
            CreateMap<VehicleDto, DBVehicleModel>();
            CreateMap<VehicleDto, DBVehicleViewVM>();
            CreateMap<VehicleDto, DBVehicleModelVM>();
            CreateMap<DBVehicleModelVM, VehicleDto>();
            CreateMap<DBVehicleModel, DBVehicleViewVM>();
        }
    }
}
