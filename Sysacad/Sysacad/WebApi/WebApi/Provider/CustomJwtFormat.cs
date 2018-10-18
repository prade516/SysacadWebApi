using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
//using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using Thinktecture.IdentityModel.Tokens;

namespace WebApi.Provider
{
	public class CustomJwtFormat : ISecureDataFormat<AuthenticationTicket>
	{
		private readonly string _issuer = string.Empty;

		// el _issuer es el emisor del token que sera la misma api, que será el que provee authorizacion y datos
		// ya que no lo tenemos separados ponemos que seriamos nosotros mismos aunque, podria pasarsea uri o un string.
		public CustomJwtFormat(string issuer)
		{
			_issuer = issuer;
		}
		public string Protect(AuthenticationTicket data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}

			string audienceId = System.Configuration.ConfigurationManager.AppSettings["as:AudienceId"];

			string symmetricKeyAsBase64 = System.Configuration.ConfigurationManager.AppSettings["as:AudienceSecret"];

			var keyByteArray = TextEncodings.Base64Url.Decode(symmetricKeyAsBase64);

			var signingKey = new HmacSigningCredentials(keyByteArray);

			var issued = data.Properties.IssuedUtc;

			var expires = data.Properties.ExpiresUtc;

			var token = new JwtSecurityToken(_issuer, audienceId, data.Identity.Claims, issued.Value.UtcDateTime, expires.Value.UtcDateTime/*, signingKey*/);

			var handler = new JwtSecurityTokenHandler();

			var jwt = handler.WriteToken(token);
			
			return jwt;
		}

		public AuthenticationTicket Unprotect(string protectedText)
		{
			throw new NotImplementedException();
		}
	}
}