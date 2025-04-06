using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Mappings
{
    public class OilProfile : Profile
    {
        public OilProfile()
        {
            CreateMap<DBOilModelVM, OilDto>();
            CreateMap<OilDto, DBOilModelVM>();
            CreateMap<DBOilModel, OilDto>();
            CreateMap<OilDto, DBOilModel>();
        }
    }
}
