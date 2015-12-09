using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(harkkakoe2.Startup))]
namespace harkkakoe2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
