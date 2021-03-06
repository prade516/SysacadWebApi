﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using WebApi.Hal;
using Microsoft.Owin.Security.OAuth;
using WebApi.Provider;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;

[assembly: OwinStartup(typeof(WebApi.Startup))]

namespace WebApi
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			HttpConfiguration httpConfig = new HttpConfiguration();
			GlobalConfiguration.Configuration.Formatters.Add(new JsonHalMediaTypeFormatter());
			GlobalConfiguration.Configuration.Formatters.Add(new XmlHalMediaTypeFormatter());
			httpConfig.Formatters.Add(new JsonHalMediaTypeFormatter());
			httpConfig.Formatters.Add(new XmlHalMediaTypeFormatter());


			ConfigureOAuthTokenGeneration(app);
			ConfigureOAuthTokenConsumption(app);

			ConfigureWebApi(httpConfig);

			app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

			app.UseWebApi(httpConfig);
		}
		private void ConfigureOAuthTokenGeneration(IAppBuilder app)
		{

			//app.CreatePerOwinContext(ApplicationDbContext.Create);
			//app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
			//app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
			//app.CreatePerOwinContext<PeatonUser>(Application)
			
			OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
			{
				//For Dev enviroment only (on production should be AllowInsecureHttp = false)

				AllowInsecureHttp = true,
				TokenEndpointPath = new PathString("/oauth/token"),
				AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
				//Provider = new CustomOAuthProvider(),
				AccessTokenFormat = new CustomJwtFormat("http://localhost:40784")
			};

			// OAuth 2.0 Bearer Access Token Generation
			app.UseOAuthAuthorizationServer(OAuthServerOptions);
		}
		private void ConfigureOAuthTokenConsumption(IAppBuilder app)
		{

			var issuer = "http://localhost:40784";
			string audienceId = System.Configuration.ConfigurationManager.AppSettings["as:AudienceId"];
			byte[] audienceSecret = TextEncodings.Base64Url.Decode(System.Configuration.ConfigurationManager.AppSettings["as:AudienceSecret"]);

			// Api controllers with an [Authorize] attribute will be validated with JWT
			app.UseJwtBearerAuthentication(
				new JwtBearerAuthenticationOptions
				{
					AuthenticationMode = AuthenticationMode.Active,
					AllowedAudiences = new[] { audienceId },
					IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
					{
						new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
					}
				});
		}
		private void ConfigureWebApi(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			var container = Bootstrapper.BuildUnityContainer();
			config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
		}
	}
}
