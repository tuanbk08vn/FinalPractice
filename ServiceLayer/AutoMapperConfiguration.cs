using AutoMapper;
using DomainLayer.Models;
using DTO;

namespace ServiceLayer
{
    public static class AutoMapperConfiguration
    {
        public static void MappingServiceLayer()
        {
            Mapper.CreateMap<Product, ProductDto>()
                .ForMember(x => x.Category, opt => opt.Ignore())
                .ForMember(x => x.SubCategory, opt => opt.Ignore()).ReverseMap();
            Mapper.CreateMap<Category, CategoryDto>().ReverseMap();
            Mapper.CreateMap<SubCategory, SubCategoryDto>().ReverseMap();
            Mapper.CreateMap<WishList, WishListDto>().ReverseMap();

        }
    }

}
