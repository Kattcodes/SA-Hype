using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FRONT_END.Startup))]
namespace FRONT_END
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
