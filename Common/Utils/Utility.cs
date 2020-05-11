using System.IO;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Common.Contract;

namespace Common.Utils
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Newtonsoft.Json.Converters;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json.Linq;
    using System.ComponentModel;
    using Common.Models;
    using Common.Configs;
    using System.Configuration;
    using RestSharp;

    public static class Utility
    {

        public static string Base64Decode(string base64EncodedData)
        {
            if (string.IsNullOrWhiteSpace(base64EncodedData))
            {
                return base64EncodedData;
            }
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }      

        public static bool IsValidJson(this string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Remove digits from string.
        /// Used to remove any specific info from PR.
        /// </summary>
        public static string RemoveDigits(this string key)
        {
            return Regex.Replace(key, @"\d", "");
        }

        public static string ToDescriptionString<T>(this T val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", nameof(description));
            // or return default(T);
        }

        public static string FigureOutLink(string location, string body, string zoomCallTip, string skypeCallTip)
        {
            var linkFromLocation = GetLinks(location);
            if (linkFromLocation?.Count > 0)
            {
                return linkFromLocation.OrderByDescending( x=> x.Length).FirstOrDefault(x => x.Contains(zoomCallTip)) ?? linkFromLocation.FirstOrDefault(x => x.Contains(skypeCallTip));
            }

            var linkFromBody = GetLinks(body);
            if (linkFromBody?.Count > 0)
            {
                return linkFromBody.FirstOrDefault(x => x.Contains(zoomCallTip)) ?? linkFromBody.FirstOrDefault(x => x.Contains(skypeCallTip));
            }

            return null;
        }

        public static List<string> GetLinks(string message)
        {
            List<string> list = new List<string>();
            try
            {
                Regex urlRx = new Regex(@"((https?|ftp|file)\://|www.)[A-Za-z0-9\.\-]+(/[A-Za-z0-9\?\&\=;\+!'\(\)\*\-\._~%]*)*", RegexOptions.IgnoreCase);

                MatchCollection matches = urlRx.Matches(message);
                foreach (Match match in matches)
                {
                    list.Add(match.Value);
                }
            }
            catch (Exception)
            {

            }
            return list;
        }

        /// <summary>
        /// Get jira tickets.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GetJiraTickets(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return null;
            }

            string taskPattern = @"\b[CMCM=]\w+-\d{6}";

            RegexOptions options = RegexOptions.Multiline;

            foreach (Match m in Regex.Matches(title, taskPattern, options))
            {
                return m?.Value;
            }

            return null;
        }

        public static bool IsJiraTicket(string id)
        {
            var result = false;

            if(id.ToUpper().Contains("CMCM"))  // can be modified for other logic 
            {
                result = true;
            }

            return result;
        }

        public static MyUtilitySettings GetSettings()
        {
            var settings = ConfigurationManager.GetSection("MyUtilitySettings") as MyUtilitySettings;

            if (settings == null)
            {
                throw new Exception("Settings are not loaded");
            }

            return settings;
        }

        public static string Authenticate(string code, IConfigurations configurations, IHttpRequestHelper httpRequestHelper, bool isAuth = true)
        {
            var authorizationUrl =
                string.Format(
                    (isAuth
                        ? configurations.CommonSettings.AuthUrl
                        : configurations.CommonSettings.MeetingUrl), configurations.CommonSettings.Tenant);
            var parameters = new Dictionary<string, Tuple<object, ParameterType>>();

            #region Commented
            //var authorizationUrl = //"https://login.microsoftonline.com/common/oauth2/v2.0/token";
            //    "https://login.microsoftonline.com/" +
            //    this.configurations.CommonSettings.Tenant +
            //    "/oauth2/v2.0/token";

            // var parameters = new Dictionary<string, Tuple<object, ParameterType>>();

            //var nvc = new List<KeyValuePair<string, string>>();
            //nvc.Add(new KeyValuePair<string, string>("grant_type", "authorization_code"));
            //nvc.Add(new KeyValuePair<string, string>("client_id", this.configurations.MeetingSettings.AppId));
            //nvc.Add(new KeyValuePair<string, string>("client_secret", this.configurations.CommonSettings.Secret));
            //nvc.Add(new KeyValuePair<string, string>("redirect_uri", this.configurations.CommonSettings.RedirectUrl));
            //nvc.Add(new KeyValuePair<string, string>("code", code));
            //nvc.Add(new KeyValuePair<string, string>("resource", this.configurations.MeetingSettings.AppId));

            //var body = new FormUrlEncodedContent(nvc);

            //var body = "grant_type=authorization_code&" +
            //           $"client_id={this.configurations.MeetingSettings.AppId}&" +
            //           $"client_secret={this.configurations.CommonSettings.Secret}&" +
            //           $"redirect_uri={this.configurations.CommonSettings.RedirectUrl}&" +
            //           $"code={code}&" +
            //          $"&resource={this.configurations.CommonSettings.Resource}"; 
            //var encodedScope = HttpUtility.UrlEncode(configurations.MeetingSettings.ScopeUrl);

            //var body = "grant_type=authorization_code&" +
            //           $"client_id={this.configurations.MeetingSettings.AppId}&" +
            //           $"client_secret={this.configurations.CommonSettings.Secret}&" +
            //           $"redirect_uri={this.configurations.CommonSettings.RedirectUrl}&" +
            //           $"code={code}&" +
            //           $"scope={encodedScope}";
            #endregion

            string body = "";

            if (isAuth)

            {
                body = "grant_type=authorization_code&" +
                           $"client_id={configurations.MeetingSettings.AppId}&" +
                           $"client_secret={configurations.CommonSettings.Secret}&" +
                           $"redirect_uri={configurations.CommonSettings.RedirectUrl}&" +
                           $"code={code}&" +
                          $"&resource={configurations.CommonSettings.Resource}";
            }
            else
            {
                var encodedScope = HttpUtility.UrlEncode(configurations.MeetingSettings.ScopeUrl);

                body = "grant_type=authorization_code&" +
                    $"client_id={configurations.MeetingSettings.AppId}&" +
                    $"client_secret={configurations.CommonSettings.Secret}&" +
                    $"redirect_uri={configurations.CommonSettings.RedirectUrl}&" +
                    $"code={code}&" +
                    $"scope={encodedScope}";
            }

            parameters.Add("body", new Tuple<object, ParameterType>(body, ParameterType.RequestBody));
            parameters.Add("Content-Type", new Tuple<object, ParameterType>("application/x-www-form-urlencoded", ParameterType.HttpHeader));

            try
            {
                var response = httpRequestHelper.CallUrl(authorizationUrl, null, null, parameters, HttpMethod.Post);
                JObject json = JObject.Parse(response);

                return json["access_token"].ToString();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.  
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException("cipherText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }

            // Declare the string used to hold  
            // the decrypted text.  
            string plaintext = null;

            // Create an RijndaelManaged object  
            // with the specified key and IV.  
            using (var rijAlg = new RijndaelManaged())
            {
                //Settings  
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.  
                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                try
                {
                    // Create the streams used for decryption.  
                    using (var msDecrypt = new MemoryStream(cipherText))
                    {
                        using(var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {

                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                // Read the decrypted bytes from the decrypting stream  
                                // and place them in a string.  
                                plaintext = srDecrypt.ReadToEnd();

                            }

                        }
                    }
                }
                catch
                {
                    plaintext = "keyError";
                }
            }

            return plaintext;
        }

        private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.  
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException("plainText");
            }
            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException("key");
            }
            byte[] encrypted;
            // Create a RijndaelManaged object  
            // with the specified key and IV.  
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Mode = CipherMode.CBC;
                rijAlg.Padding = PaddingMode.PKCS7;
                rijAlg.FeedbackSize = 128;

                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.  
                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.  
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.  
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.  
            return encrypted;
        }

        public static string DecryptStringAES(string cipherText)
        {
            var keybytes = Encoding.UTF8.GetBytes("8080808080808080");
            var iv = Encoding.UTF8.GetBytes("8080808080808080");

            var encrypted = Convert.FromBase64String(cipherText);
            var decriptedFromJavascript = DecryptStringFromBytes(encrypted, keybytes, iv);
            return string.Format(decriptedFromJavascript);
        }

        public static List<string> ExtractEmails(string textToScrape)
        {
            Regex reg = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);
            Match match;

            List<string> results = new List<string>();
            for (match = reg.Match(textToScrape); match.Success; match = match.NextMatch())
            {
                if (!(results.Contains(match.Value)))
                    results.Add(match.Value);
            }

            return results;
        }
    }

    public static class Serialize
    {
        public static string ToJson(this JiraResponse self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    //For JSON

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    /// <summary>
    /// Constants for claim types.
    /// </summary>
    public static class ClaimConstants
    {
        public const string Name = "name";
        public const string ObjectId = "http://schemas.microsoft.com/identity/claims/objectidentifier";
        public const string Oid = "oid";
        public const string PreferredUserName = "preferred_username";
        public const string TenantId = "http://schemas.microsoft.com/identity/claims/tenantid";
        public const string Tid = "tid";
        public const string ScopeClaimType = "http://schemas.microsoft.com/identity/claims/scope";
        public const string ScpClaimType = "scp";
        public const string RolesClaimType = "roles";

        public const string ScopeClaimValue = "access_as_user";

    }
}
