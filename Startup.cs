using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Pass.Startup))]
namespace Pass
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
