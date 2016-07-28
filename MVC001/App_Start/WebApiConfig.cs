using System.Web.Http;

namespace MVC001.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API Configuration and services

            //Web API Route - Imported the Web API 2.0+ attribute route feature
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name:"DefaultApi",
                routeTemplate:"api/{controller}/{id}",
                defaults:new {id=RouteParameter.Optional}
                );
        }
    }
}