using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CompanyWebPage.Startup))]
namespace CompanyWebPage
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
