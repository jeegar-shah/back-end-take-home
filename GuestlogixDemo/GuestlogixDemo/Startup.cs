using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GuestlogixDemo.Startup))]
namespace GuestlogixDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
