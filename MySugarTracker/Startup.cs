using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MySugarTracker.Startup))]
namespace MySugarTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
