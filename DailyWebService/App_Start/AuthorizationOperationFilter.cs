using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;
using Common.Utils;
using Swashbuckle.Swagger;

namespace DailyWebService.App_Start
{
    public class AuthorizationOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            operation.parameters.Add(new Parameter()
            {
                type = "string",
                name = "Authorization",
                description = "access token",
                required = false,
                @in = "header",
                @default = $"bearer {SingletonAction.token}"
            });
        }
    }
}