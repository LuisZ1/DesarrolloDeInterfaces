using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(piedraService.Startup))]

namespace piedraService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
            app.MapSignalR();
        }
    }
}