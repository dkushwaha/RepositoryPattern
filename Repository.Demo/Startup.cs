using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Repository.Demo.Startup))]
namespace Repository.Demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
