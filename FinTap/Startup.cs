using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FinTap.Startup))]
namespace FinTap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
