using AutoMapper;
using Omadiko.Entities;
using Omadiko.Entities.Models;

namespace Omadiko.WebApi.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<ApplicationUser, ApplicationUserDto>();
            Mapper.CreateMap<ApplicationUserDto, ApplicationUser>();
        }
    }
}