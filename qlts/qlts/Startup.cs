using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(qlts.Startup))]
namespace qlts
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}