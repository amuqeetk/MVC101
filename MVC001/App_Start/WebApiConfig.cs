using System.Web.Http;

namespace MVC001.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API Configuration and Service

            //Web API Route
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name:"DefaultApi",
                routeTemplate:"api/{controller}/{id}",
                defaults:new {id=RouteParameter.Optional}
                );
        }
    }
}