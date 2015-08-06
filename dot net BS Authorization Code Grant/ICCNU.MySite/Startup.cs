using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ICCNU.MySite.Startup))]
namespace ICCNU.MySite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
