using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Mappings
{
    public class TireProfile : Profile
    {
        public TireProfile()
        {
            CreateMap<TireDto,DBTiresModelVM>();
            CreateMap<TireDto,DBTiresModel>();
            CreateMap<DBTiresModelVM, TireDto>();
            CreateMap<DBTiresModel, TireDto>();
        }

    }
}
