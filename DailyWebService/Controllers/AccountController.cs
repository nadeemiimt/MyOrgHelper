using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Common.Contract;
using Common.Utils;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DailyWebService.Controllers
{
    //https://login.microsoftonline.com/onevmw.onmicrosoft.com/oauth2/authorize?client_id=b8660bcd-0c4b-4f36-93d9-113e00e61e5e&response_type=code&redirect_uri=http://localhost:63181/api/Account/
    //https://login.microsoftonline.com/onevmw.onmicrosoft.com/oauth2/v2.0/authorize?client_id=b8660bcd-0c4b-4f36-93d9-113e00e61e5e&response_type=code&redirect_uri=http://localhost:63181/api/Account/&scope=https%3A%2F%2Fgraph.microsoft.com%2Fcalendars.read.shared%20https%3A%2F%2Fgraph.microsoft.com%2Fmail.send
    //https://login.microsoftonline.com/onevmw.onmicrosoft.com/oauth2/v2.0/authorize?client_id=b8660bcd-0c4b-4f36-93d9-113e00e61e5e&response_type=code&redirect_uri=http://localhost:63181/api/Account/&scope=https%3A%2F%2Foutlook.office.com%2FEWS.AccessAsUser.All

    public class AccountController : ApiController
    {
        private readonly IConfigurations configurations;
        private readonly IHttpRequestHelper httpRequestHelper;
        public AccountController(IConfigurations configurations, IHttpRequestHelper httpRequestHelper)
        {
            this.configurations = configurations;
            this.httpRequestHelper = httpRequestHelper;
        }

        // GET api/<controller>
        [HttpGet]
        public string TokenCallBack(string code, string session_state)
        {
            SingletonAction.code = code;
            return code;
        }

        
        [HttpPost]
        [Route("account/token")]
        public string Token([FromBody]string code)
        {
            var result = Utility.Authenticate(code, this.configurations, this.httpRequestHelper, true);

            return result;
        }
    }
}