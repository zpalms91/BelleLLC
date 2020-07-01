using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BelleEssense.UI.Startup))]
namespace BelleEssense.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
