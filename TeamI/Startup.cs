using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamI.Startup))]
namespace TeamI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
