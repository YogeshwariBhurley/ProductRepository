using Microsoft.Owin;
using Owin;
using ProductDemoApplication.AutomapperCode;

[assembly: OwinStartupAttribute(typeof(ProductDemoApplication.Startup))]
namespace ProductDemoApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            AutoMapperInit.Initialize();
        }
    }
}
