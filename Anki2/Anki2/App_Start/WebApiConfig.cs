using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http.Headers;

namespace Anki2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{action}"
			);
			System.Web.Http.GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
			config.Formatters.Insert(0, new System.Net.Http.Formatting.JsonMediaTypeFormatter());
			config.Formatters.Insert(0, new System.Net.Http.Formatting.FormUrlEncodedMediaTypeFormatter());



		}
	}
}
