using AutoMapper;
using FinalPractice.DAL;
using FinalPractice.ViewModels;
using Infracstructure.DAL;

namespace FinalPractice
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserUpdateViewModel>();
            CreateMap<UserUpdateViewModel, ApplicationUser>();
        }
    }
}