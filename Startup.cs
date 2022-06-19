using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Cookizi.StartupOwin))]

namespace Cookizi
{
    public partial class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            //AuthStartup.ConfigureAuth(app);
        }
    }
}
