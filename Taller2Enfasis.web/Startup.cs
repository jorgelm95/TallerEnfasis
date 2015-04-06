using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Taller2Enfasis.web.Startup))]
namespace Taller2Enfasis.web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
