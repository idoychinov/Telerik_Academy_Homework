using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestWebFormsApp.Startup))]
namespace TestWebFormsApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
