using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CyberAcademy.Web;
using System.Web.Mvc;
using System.Web.Routing;
using CyberAcademy.Web.App_Start;

[assembly:OwinStartup(typeof(Startup))]
namespace CyberAcademy.Web
{
    public partial class Startup
    {
        public static void Configuration(IAppBuilder app)
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.Configure(GlobalFilters.Filters);
            ConfigureAuth(app);
        }
    }
}