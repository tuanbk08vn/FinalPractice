using AutoMapper;
using FinalPractice.UserModel;
using FinalPractice.ViewModels;

namespace FinalPractice
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, RegisterViewModel>();
            CreateMap<RegisterViewModel, ApplicationUser>();
        }
    }
}