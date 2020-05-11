using System;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using Common.Contract;
using DailyWebService.App_Start;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Unity;
using Unity.AspNet.WebApi;

namespace DailyWebService
{
    public partial class Startup
    {

        public void ConfigureAuth(IAppBuilder app)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;

            // Allow cross-domain requests
            //app.UseCors(CorsOptions.AllowAll);
            //ConfigureOAuth(app);

            var container = UnityConfig.Container;
            config.DependencyResolver = new UnityDependencyResolver(container);

            var configurations = container.Resolve<IConfigurations>();

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    Tenant = configurations.CommonSettings.Tenant,
                    TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidAudience = configurations.CommonSettings.Audience
                    },
                    TokenHandler = new JwtSecurityTokenHandler(),
                });

            //app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions()
            //{
            //    TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidIssuer = "https://issuer.example.com",

            //        ValidateAudience = true,
            //        ValidAudience = "https://yourapplication.example.com",

            //        ValidateLifetime = true,
            //    }
            //});

            //  GlobalConfiguration.Configuration.MessageHandlers.Add(new TokenValidationHandler(configurations));

            GlobalConfiguration.Configure(WebApiConfig.Register);

            app.UseWebApi(config);
        }

        private void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/oauth/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(30),
                Provider = new AuthorizationServerProvider()
            };

            //Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }

    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();

        //    return base.ValidateClientAuthentication(context);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Add parameters to token
            ClaimsIdentity oAuthIdentity = new ClaimsIdentity(context.Options.AuthenticationType);
        //    oAuthIdentity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));

            context.Validated(oAuthIdentity);

         //   return base.GrantResourceOwnerCredentials(context);
        }
    }
}
