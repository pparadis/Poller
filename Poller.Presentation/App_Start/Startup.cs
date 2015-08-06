using Microsoft.Owin;

[assembly: OwinStartup(typeof(Poller.Presentation.Startup))]
namespace Poller.Presentation
{
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}