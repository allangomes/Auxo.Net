using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Auxo.Api.Security
{
    public static class Extensions
    {
        public static IServiceCollection AddSecurity(this IServiceCollection services, TokenSettings tokenSettings)
        {
            tokenSettings.Credentials = new SigningCredentials(tokenSettings.Key, SecurityAlgorithms.RsaSha256Signature);
            services.AddSingleton(tokenSettings);
            return services;
        }

        public static IApplicationBuilder UseSecurity(this IApplicationBuilder app)
        {
            var tokenSettings = app.ApplicationServices.GetRequiredService<TokenSettings>();
            var options = new JwtBearerOptions
            {
                TokenValidationParameters = new TokenValidationParameters 
                {
                    IssuerSigningKey = tokenSettings.Key,
                    ValidIssuer = tokenSettings.Issuer,
                    ValidAudience = tokenSettings.Audience,
                    ValidateLifetime = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateIssuerSigningKey = true,
                    RequireExpirationTime = true
                },
                SaveToken = true,
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                Audience = tokenSettings.Audience
            };
            app.UseJwtBearerAuthentication(options);
            return app;
        }
    }
}