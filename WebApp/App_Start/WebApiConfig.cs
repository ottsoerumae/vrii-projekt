using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;

            // remove xml formatter
            formatters.Remove(formatters.XmlFormatter);

            // json referenceloop
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            // json referenceloop objects
            jsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            // pretty output
            jsonFormatter.SerializerSettings.Formatting = Formatting.Indented;

            // response case
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // ignore null objects
            jsonFormatter.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;

            //// change the DateTime format
            //jsonFormatter.SerializerSettings.DateFormatHandling = DateFormatHandling.MicrosoftDateFormat;

            //// TimeZone format?
            //jsonFormatter.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;

            //// culture of the serializer
            //jsonFormatter.SerializerSettings.Culture = new CultureInfo("et-EE");

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
