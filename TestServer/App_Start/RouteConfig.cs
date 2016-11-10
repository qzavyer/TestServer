using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestServer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapHttpRoute("api", "api/{controller}/{id}",
                new {id = UrlParameter.Optional});
            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional});
        }
    }
}
