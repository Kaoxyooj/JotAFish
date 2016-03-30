using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JotAFish.Startup))]
namespace JotAFish
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
