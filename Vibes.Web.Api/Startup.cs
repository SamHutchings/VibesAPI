using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(Vibes.Web.Api.App_Start.Startup))]
namespace Vibes.Web.Api
{
	public partial class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var config = new HttpConfiguration();
			ConfigureAuth(app);
			WebApiConfig.Register(config);
			app.UseWebApi(config);
		}
	}
}