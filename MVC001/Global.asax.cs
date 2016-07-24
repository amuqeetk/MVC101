using MVC001.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC001
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var bookContext = new BookContext();
            Database.SetInitializer(new BookInitializer());
            bookContext.Database.Initialize(true);


            MvcHandler.DisableMvcResponseHeader = true;

        }

        protected void Application_PreSendRequestHeader()
        {
            HttpContext.Current.Request.Headers.Set("Server", "Scott Lau");
        }
    }
}
