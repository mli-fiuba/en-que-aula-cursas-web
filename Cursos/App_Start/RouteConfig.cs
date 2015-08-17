using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cursos
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            //API
            routes.MapRoute(
                name: "API-Departamentos",
                url: "api",
                defaults: new { controller = "API", action = "Departamentos" }
            );

            routes.MapRoute(
                name: "API-Materias",
                url: "api/{departamento}",
                defaults: new { controller = "API", action = "Materias" }
            );

            routes.MapRoute(
                name: "API-Cursos",
                url: "api/{departamento}/{materia}",
                defaults: new { controller = "API", action = "Cursos" }
            );

            routes.MapRoute(
                name: "API-Curso",
                url: "api/{departamento}/{materia}/{curso}",
                defaults: new { controller = "API", action = "Curso" }
            );

            //APP
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            
        }
    }
}
