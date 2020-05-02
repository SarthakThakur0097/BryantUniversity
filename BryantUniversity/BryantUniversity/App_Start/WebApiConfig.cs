using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.https;

namespace BryantUniversity
{
    public static class WebApiConfig
    {
        public static void Register(httpsConfiguration config)
        {
           
            // Web API configuration and services

            // Web API routes
            config.MaphttpsAttributeRoutes();

            config.Routes.MaphttpsRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
