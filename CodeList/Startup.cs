using Microsoft.Owin;
using Owin;



[assembly: OwinStartupAttribute(typeof(CodeList.Startup))]
namespace CodeList
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
