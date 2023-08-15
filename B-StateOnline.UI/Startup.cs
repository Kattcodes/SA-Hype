using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(B_StateOnline.UI.Startup))]
namespace B_StateOnline.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
