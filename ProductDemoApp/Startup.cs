using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductDemoApp.Startup))]
namespace ProductDemoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
