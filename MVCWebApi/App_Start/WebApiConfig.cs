﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using MVCWebApi.Controllers;

namespace MVCWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();
            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
        }
    }
}
