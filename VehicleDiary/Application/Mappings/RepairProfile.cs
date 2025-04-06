using AutoMapper;
using Microsoft.Identity.Client;
using VehicleDiary.Application.DTOs;
using VehicleDiary.Core.Entities;
using VehicleDiary.Web.ViewModels;

namespace VehicleDiary.Application.Mappings
{
    public class RepairProfile : Profile
    {
        public RepairProfile()
        {
            CreateMap<DBRepairModelVM,RepairDto>();
            CreateMap<RepairDto,DBRepairModelVM>();
            CreateMap<DBRepairsModel,RepairDto>();
            CreateMap<RepairDto, DBRepairsModel>();
        }
    }
}
