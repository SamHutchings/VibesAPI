using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;
using System.Web.Http.ExceptionHandling;
using Vibes.Web.Api.Infrastructure;

namespace Vibes.Web.Api
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

			config.Services.Add(typeof(IExceptionLogger), new CustomExceptionLogger());

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "{controller}/{id}/{action}",
				defaults: new { controller = "Default", id = RouteParameter.Optional, action = RouteParameter.Optional }
			);
		}
	}
}
