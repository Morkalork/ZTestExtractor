using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZTestExtractor.MVC.Startup))]
namespace ZTestExtractor.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
