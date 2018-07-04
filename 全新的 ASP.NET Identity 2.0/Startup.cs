using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(全新的_ASP.NET_Identity_2._0.Startup))]
namespace 全新的_ASP.NET_Identity_2._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
