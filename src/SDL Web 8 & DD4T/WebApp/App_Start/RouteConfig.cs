using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "FindPageId",
                url: "findPageId/{*uri}",
                defaults: new { controller = "Home", action = "FindPageId" }
            );

            routes.MapRoute(
                name: "GetPageById",
                url: "getPageById/{*pageId}",
                defaults: new { controller = "Home", action = "GetPageById" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
