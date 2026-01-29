using AutoMapper;
using PfsDomain.Entities;
using PfsShared.ViewModels;

namespace PfsInfrastructure.Configurations
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration() 
        {
            CreateMap<UserViewModel, User>()
                .ReverseMap();
        }
    }
}
