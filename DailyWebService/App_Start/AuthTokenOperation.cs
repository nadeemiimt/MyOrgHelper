using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Common.Contract;
using Common.Utils;
using Swashbuckle.Swagger;
using Unity;

namespace DailyWebService.App_Start
{
    public class AuthTokenOperation : IDocumentFilter
    {
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            var container = UnityConfig.Container;
            var configuration = container.Resolve<IConfigurations>();
            swaggerDoc.paths.Add("/oauth/token", new PathItem
            {
                post = new Operation()
                {
                    tags = new List<string>() { "Auth"},
                    consumes = new List<string>()
                    {
                        "application/x-www-form-urlencoded"
                    },
                    parameters = new List<Parameter>()
                    {
                        new Parameter()
                        {
                            type = "string",
                            name = "grant_type",
                            required = true,
                            @in="formData",
                            @default = "authorization_code"
                        },
                        new Parameter()
                        {
                            type = "string",
                            name = "client_id",
                            required = true,
                            @in="formData",
                            @default = configuration.MeetingSettings.AppId
                        },
                        new Parameter()
                        {
                            type = "string",
                            name = "client_secret",
                            required = true,
                            @in="formData",
                            @default = configuration.CommonSettings.Secret
                        },
                        new Parameter()
                        {
                            type = "string",
                            name = "redirect_uri",
                            required = true,
                            @in="formData",
                            @default = configuration.CommonSettings.RedirectUrl
                        },
                        new Parameter()
                        {
                            type = "string",
                            name = "code",
                            required = true,
                            @in="formData",
                            @default = SingletonAction.code
                        },
                        new Parameter()
                        {
                            type = "string",
                            name = "resource",
                            required = true,
                            @in="formData",
                            @default = configuration.MeetingSettings.AppId
                        },
                    }
                }
            });
        }
    }
}