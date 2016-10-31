using System;
using Microsoft.IdentityModel.Tokens;

namespace Auxo.Api.Security
{
    public class TokenSettings
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public SecurityKey Key { get; set; }
        public SigningCredentials Credentials;
        public TimeSpan ExpireIn { get; set; }
    }
}