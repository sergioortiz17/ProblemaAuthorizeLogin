using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCWebApi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}", //2.- aca define como tiene que ser la URL tiene que estar el controlador la accion y el id
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } //3.-home y va a index serian las rutas por defecto (homeController)
            );
        }
    }
}
