using System;
using System.Text;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using DAL.EFCore;
using Entities.Auth;

namespace WebAPI;

public static class ConfigurationServices
{
    public static IServiceCollection AddWebAPIConfigurations(this IServiceCollection services, IConfiguration configuration)
    {
        // IDENTITY
        services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MeetzyDbContext>().AddDefaultTokenProviders();

        // JWT
        services.AddAuthentication(opt =>
        {
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(opt =>
        {
            var tokenOptions = configuration.GetSection("TokenOptions").Get<Entities.Auth.TokenOptions>();
            opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = tokenOptions.Issuer,
                ValidAudience = tokenOptions.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                ClockSkew = TimeSpan.Zero
            };
        });

        // OUTPUT
        return services;
    }
}
