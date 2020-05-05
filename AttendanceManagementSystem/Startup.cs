using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AttendanceManagementSystem.Startup))]
namespace AttendanceManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
