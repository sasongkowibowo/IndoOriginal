using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IndoOriginal.Startup))]
namespace IndoOriginal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
