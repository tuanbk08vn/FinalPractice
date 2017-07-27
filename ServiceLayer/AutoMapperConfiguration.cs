using AutoMapper;
using DomainLayer.Models;
using DTO;

namespace ServiceLayer
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingServiceLayer>();
            });



        }
    }

    public class MappingServiceLayer : Profile
    {
        public MappingServiceLayer()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

        }

    }
}
