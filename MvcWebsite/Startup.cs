using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcWebsite.Startup))]
namespace MvcWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
