﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DigitalLibrary.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "DigitalLibrary.Web.Controllers" }
            );

            routes.MapRoute(
              name: "Admin",
              url: "{area}/{controller}/{action}/{id}",
              defaults: new {area="Admonistration", controller = "Home", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "DigitalLibrary.Web.Areas.Administration" }
          );


            routes.MapRoute(
               name: "StaticPages",
               url: "{action}",
               defaults: new { controller = "Home" },
               namespaces: new[] { "DigitalLibrary.Web.Controllers" }
           );
        }
    }
}
