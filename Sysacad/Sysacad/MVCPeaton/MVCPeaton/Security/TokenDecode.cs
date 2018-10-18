using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Web;

namespace MVCPeaton.Security
{
    public class TokenDecode
    {
        private static TokenDecode _tokenDecode;
        private TokenDecode() { }

        public static TokenDecode GetInstance()
        {
            if (_tokenDecode == null)
                _tokenDecode = new TokenDecode();
            return _tokenDecode;
        }

        public DataValues Decode(TokenGrant protectedText)
        { 
            var handler = new System.IdentityModel.Tokens.JwtSecurityTokenHandler();
            JwtSecurityToken st = (JwtSecurityToken)handler.ReadToken(protectedText.access_token);
            List<string> Roles = new List<string>();
            List<string> Claims = new List<string>();
            DataValues mdv = new DataValues();
            mdv.Token = protectedText.access_token;
            foreach (var claim in st.Claims)
            {
                if (claim.Type.Equals("role"))
                {
                    Roles.Add(claim.Value);
                }
                else if (!claim.Type.Equals("iss") && !claim.Type.Equals("aud") && !claim.Type.Equals("nbf") &&
                   !claim.Type.Equals("exp") && !claim.Type.Equals("nameid") &&
                   !claim.Type.Equals("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider")
                   && !claim.Type.Equals("AspNet.Identity.SecurityStamp") && !claim.Type.Equals("exp"))
                {
                    Claims.Add(claim.Type+"|"+claim.Value);
                }
            }
            string delimiter = ",";
            
            mdv.Roles = Roles.Aggregate((i, j) => i + delimiter + j);
            mdv.Claims = Claims.Aggregate((i, j) => i + delimiter + j);
            TimeSpan time = TimeSpan.FromSeconds(protectedText.expires_in);
            mdv.ExpireToken = DateTime.Now.AddHours(time.Hours).AddMinutes(time.Minutes).AddSeconds(time.Seconds - 20);
            mdv.PrincipalId = protectedText.principalid;
            return mdv;
        }
    }
}