using Common.Contract;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace DataLogic
{
    /// <summary>
    /// Http helper to work with RestSharp.
    /// </summary>
    public class HttpRequestHelper : IHttpRequestHelper
    {
        public string CallUrl(string url, string userName, string password, Dictionary<string, Tuple<object, ParameterType>> parameters, HttpMethod method)
        {
            var client = new RestClient(url);

            if (!string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
            {
                client.Authenticator = new HttpBasicAuthenticator(userName, password);
            }

            var request = new RestRequest(url, DataFormat.Json);
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    request.AddOrUpdateParameter(param.Key, param.Value.Item1, param.Value.Item2);
                }
            }

            IRestResponse response = null;

            if (method == HttpMethod.Get)
            {
                response = client.Get(request);
            }
            else if (method == HttpMethod.Post)
            {
                response = client.Post(request);
            }
            else if (method == HttpMethod.Delete)
            {
                response = client.Delete(request);
            }
            else if (method == HttpMethod.Put)
            {
                response = client.Put(request);
            }

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response?.Content?.ToString();
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {

                return "";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                new Exception("Unauthorized request.");
            }
            else
            {
                new Exception("Content not found or error in response.");
            }

            return response.StatusDescription + "##" + response.ErrorMessage;
        }

        public string CallUrl(string url, string userName, string password, HttpMethod httpMethod, bool followRedirect = true)
        {
            using (var client = new HttpClient(new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip, AllowAutoRedirect = followRedirect }) { Timeout = TimeSpan.FromMinutes(1) })
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(
                System.Text.ASCIIEncoding.ASCII.GetBytes(
                   $"{userName}:{password}")));

                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(url),
                    Method = httpMethod
                };

                HttpResponseMessage response = client.SendAsync(request).Result;
                var statusCode = (int)response.StatusCode;

                // We want to handle redirects ourselves so that we can determine the final redirect Location (via header)
                if (!followRedirect)
                {
                    if (statusCode >= 300 && statusCode <= 399)
                    {
                        var redirectUri = response.Headers.Location;
                        if (!redirectUri.IsAbsoluteUri)
                        {
                            redirectUri = new Uri(request.RequestUri.GetLeftPart(UriPartial.Authority) + redirectUri);
                        }
                        //_status.AddStatus(string.Format("Redirecting to {0}", redirectUri));
                        return CallUrl(redirectUri.OriginalString, userName, password, httpMethod);
                    }
                    else if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception();
                    }
                }
                return response?.Content?.ReadAsStringAsync()?.Result;
            }
        }
    }
}
