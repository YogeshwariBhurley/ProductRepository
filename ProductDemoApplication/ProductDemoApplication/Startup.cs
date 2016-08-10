using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductDemoApplication.Startup))]
namespace ProductDemoApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
