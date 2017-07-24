using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinalPractice.Startup))]
namespace FinalPractice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
