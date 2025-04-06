using AutoMapper;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Mappings
{
    public class PetrolProfile : Profile
    {
        public PetrolProfile()
        {
            CreateMap<PetrolDto, DBPetrolModel>();
            CreateMap<PetrolDto, DBPetrolModelVM>();
            CreateMap<DBPetrolModel, PetrolDto>();
            CreateMap<DBPetrolModelVM, PetrolDto>();
        }
    }
}
