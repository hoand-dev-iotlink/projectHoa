using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectAuthen.Startup))]
namespace ProjectAuthen
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
