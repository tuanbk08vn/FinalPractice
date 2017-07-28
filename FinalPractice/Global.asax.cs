using System;
using System.Linq.Expressions;
using AutoMapper;
using DTO;
using FinalPractice.UserModel;
using FinalPractice.ViewModels;
using ServiceLayer;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DomainLayer.Models;

namespace FinalPractice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MappingProfileConfig();
            AutoMapperConfiguration.MappingServiceLayer();
        }


        private void MappingProfileConfig()
        {
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();
            //CreateMap<categoryViewModel, categoryDto>();
            //CreateMap<categoryFormViewModel, categoryDto>();
            Mapper.CreateMap<CategoryDto, CategoryViewModel>().ReverseMap();
            Mapper.CreateMap<SubCategoryDto, SubCategoryViewModel>().ReverseMap();
            Mapper.CreateMap<ProductDto, ProductViewModel>().ReverseMap();
            Mapper.CreateMap<ProductDto, ProductFormViewModel>().ReverseMap();
            Mapper.CreateMap<ProductDto, ProductEditViewModel>().ReverseMap();

        }
    }
}
