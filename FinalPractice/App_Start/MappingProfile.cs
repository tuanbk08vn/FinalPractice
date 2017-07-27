using AutoMapper;
using FinalPractice.UserModel;
using FinalPractice.ViewModels;

namespace FinalPractice
{
    public class MappingProfile : Profile
    {
        public static void MappingProfileConfig()
        {
            CreateMap<ApplicationUser, RegisterViewModel>();
            CreateMap<RegisterViewModel, ApplicationUser>();
            //CreateMap<ProductViewModel, ProductDto>();
            //CreateMap<ProductFormViewModel, ProductDto>();
            CreateMap<DTO.ProductDto, ProductViewModel>();
            CreateMap<ProductViewModel, DTO.ProductDto>();

        }
    }
}