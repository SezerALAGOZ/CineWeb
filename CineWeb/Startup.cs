using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CineWeb.Startup))]
namespace CineWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
