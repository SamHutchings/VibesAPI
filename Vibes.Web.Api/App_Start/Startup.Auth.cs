using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;

namespace Vibes.Web.Api.App_Start
{
	public partial class Startup
	{
		static Startup()
		{
			OAuthOptions = new OAuthAuthorizationServerOptions
			{
				TokenEndpointPath = new PathString("/token"),
				Provider = new ApplicationOAuthProvider(),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				AllowInsecureHttp = true
			};

			OAuthBearerOptions = new OAuthBearerAuthenticationOptions();
		}

		public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
		public static OAuthBearerAuthenticationOptions OAuthBearerOptions { get; private set; }

		public static string PublicClientId { get; private set; }

		public void ConfigureAuth(IAppBuilder app)
		{
			app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions
			{
				AccessTokenProvider = new AuthenticationTokenProvider()
			});
			app.UseOAuthBearerTokens(OAuthOptions);

			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

		}
	}
}