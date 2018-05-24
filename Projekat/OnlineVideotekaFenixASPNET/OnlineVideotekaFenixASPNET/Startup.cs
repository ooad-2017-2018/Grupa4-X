using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineVideotekaFenixASPNET.Startup))]
namespace OnlineVideotekaFenixASPNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
