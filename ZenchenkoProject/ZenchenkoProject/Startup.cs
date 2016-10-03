using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZenchenkoProject.Startup))]
namespace ZenchenkoProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
