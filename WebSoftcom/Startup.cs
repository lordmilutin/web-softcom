using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebSoftcom.Startup))]
namespace WebSoftcom
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
