using AutoMapper;
using FinalPractice.UserModel;
using FinalPractice.ViewModels;
using ServiceLayer;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FinalPractice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            Mapper.Initialize(c =>
            {
                c.AddProfile<MappingProfile>();

            });
            AutoMapperConfiguration.Configure();
            MappingProfileConfig();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        public void MappingProfileConfig()
        {
            Mapper.CreateMap<ApplicationUser, RegisterViewModel>();
            Mapper.CreateMap<RegisterViewModel, ApplicationUser>();
            //CreateMap<ProductViewModel, ProductDto>();
            //CreateMap<ProductFormViewModel, ProductDto>();
            Mapper.CreateMap<DTO.ProductDto, ProductViewModel>();
            Mapper.CreateMap<ProductViewModel, DTO.ProductDto>();

        }
    }
}
