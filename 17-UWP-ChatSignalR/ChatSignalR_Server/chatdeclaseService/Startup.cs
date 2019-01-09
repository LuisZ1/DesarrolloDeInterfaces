using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(chatdeclaseService.Startup))]

namespace chatdeclaseService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}