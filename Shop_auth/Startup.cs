using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shop_auth.Startup))]
namespace Shop_auth
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
