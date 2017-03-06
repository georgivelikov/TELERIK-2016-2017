using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Fancy.Web.Startup))]
namespace Fancy.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
