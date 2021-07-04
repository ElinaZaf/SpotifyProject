using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Omadiko.WebApp.Startup))]
namespace Omadiko.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
