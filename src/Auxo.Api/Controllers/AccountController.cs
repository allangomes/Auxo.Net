using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Auxo.Api.Security;
using Auxo.Business;
using Auxo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Auxo.Api.Controllers
{
    [Route("[controller]")]
    public class AccountController<T>
        where T : Entity, IUser
    {
        private readonly IUserService<T> _users;
        private readonly TokenSettings _tokenSettings;

        public AccountController(IUserService<T> users, TokenSettings tokenSettings)
        {
            _users = users;
            _tokenSettings = tokenSettings;
        }

        protected virtual Claim[] GetClaims(T user)
        {
            return new[] {
                new Claim("id", user.Id.ToString(), ClaimValueTypes.String)
            };
        }

        protected virtual string Token(T user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new GenericIdentity(user.Id.ToString(), "TokenAuth"), GetClaims(user));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _tokenSettings.Issuer,
                Audience = _tokenSettings.Audience,
                SigningCredentials = _tokenSettings.Credentials,
                Subject =  identity,
                NotBefore = DateTime.Now,
                Expires = expires
            };
            var securityToken = handler.CreateToken(tokenDescriptor);
            var token = handler.WriteToken(securityToken);
            return token;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public object Login([FromBody] UserPass obj)
        {
            var user = _users.Authenticate(obj.Pass, obj.Password);
            if (user)
            {
                var expires = DateTime.Now.Add(_tokenSettings.ExpireIn);
                var token = Token(user, expires);
                return new { Authenticated = true, EntityId = user.Id, Token = token, ExpiresAt = expires };
            }
            else
            {
                Console.WriteLine("401");
                return Result.Factory(HttpStatusCode.Unauthorized, null);
            }
        } 

        public class UserPass
        {
            public string Pass { get; set; }
            public string Password { get; set; }
        }
    }
}