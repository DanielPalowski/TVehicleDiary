using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Mappings
{
	public class VignetteProfile : Profile
	{
        public VignetteProfile()
        {
            CreateMap<DBVignetteModelVM, VignetteDto>();
            CreateMap<VignetteDto, DBVignetteModelVM>();
            CreateMap<DBVignetteModel, VignetteDto>();
            CreateMap<VignetteDto, DBVignetteModel>();
        }
    }
}
