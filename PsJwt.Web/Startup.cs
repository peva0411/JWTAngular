using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PsJwt.Web.Startup))]
namespace PsJwt.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
