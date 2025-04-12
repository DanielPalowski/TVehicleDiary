using AutoMapper;
using Microsoft.Identity.Client;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Mappings
{
    public class CarUsageProfile : Profile
    {
        public CarUsageProfile()
        {
            CreateMap<TireDto,DBCarUsageOverViewVM>();
            CreateMap<OilDto, DBCarUsageOverViewVM>();
            CreateMap<PetrolDto, DBCarUsageOverViewVM>();
            CreateMap<VignetteDto, DBCarUsageOverViewVM>();
            CreateMap<DBCarUsageOverViewVM, TireDto>();
            CreateMap<DBCarUsageOverViewVM, OilDto>();
            CreateMap<DBCarUsageOverViewVM, PetrolDto>();
            CreateMap<DBCarUsageOverViewVM, VignetteDto>();


        }
    }
}
