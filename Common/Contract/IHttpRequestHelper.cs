using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Common.Contract
{
    public interface IHttpRequestHelper
    {
        string CallUrl(string url, string userName, string password, Dictionary<string, Tuple<object, ParameterType>> parameters, HttpMethod method);

        string CallUrl(string url, string userName, string password, HttpMethod httpMethod, bool followRedirect = true);
    }
}
