using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProductApp.Startup))]
namespace ProductApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
