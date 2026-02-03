using AutoMapper;
using PfsDomain.Entities;
using PfsShared.ViewModels;

namespace PfsInfrastructure.Configurations.Mapper
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration() 
        {
            CreateMap<UserViewModel, User>()
                .ForMember(d => d.FirstName, opt => opt.NullSubstitute(string.Empty))
                .ForMember(d => d.LastName, opt => opt.NullSubstitute(string.Empty))
                .ForMember(d => d.RefreshToken, opt => opt.NullSubstitute(string.Empty))
                .ForMember(d => d.AccessToken, opt => opt.NullSubstitute(string.Empty))
                .ReverseMap();

            CreateMap<UserViewModel.Create.UserRequest, User>()
                .ForMember(d => d.FirstName, opt => opt.NullSubstitute(string.Empty))
                .ForMember(d => d.FirstName, opt => opt.NullSubstitute(string.Empty))
                .ForMember(d => d.FirstName, opt => opt.NullSubstitute(string.Empty))
                .ForMember(d => d.FirstName, opt => opt.NullSubstitute(string.Empty))
                .ForMember(d => d.FirstName, opt => opt.NullSubstitute(string.Empty))
                .ReverseMap();
        }
    }
}
