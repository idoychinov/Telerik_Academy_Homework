using System;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Owin;

using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

using Forum.Data;

[assembly: OwinStartup(typeof(Forum.WebApi.Startup))]

namespace Forum.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<IForumData>().To<ForumData>().WithConstructorArgument("context", c => new ForumDbContext());
        }
    }
}
