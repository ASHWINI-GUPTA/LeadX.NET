using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LeadX.NET.Exceptions;
using LeadX.NET.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LeadX.NET
{
    public class RestClient : IRestClient
    {
        private readonly LeadX _leadX;
        private readonly HttpClient _httpClient;

        public RestClient(LeadX leadX)
        {
            _leadX = leadX;
            _httpClient = new HttpClient();
            Url = "https://api.leadx.app";
        }

        public string Url { get; }

        private HttpRequestMessage PrepareRequest(Uri requestUri, HttpMethod method, object payload = null)
        {
            var httpRequest = new HttpRequestMessage {RequestUri = requestUri};
            httpRequest.Headers.Add("Authorization", $"Bearer {_leadX.Authorization.GetAccessToken()}");
            httpRequest.Headers.Add("vendorId", _leadX.VendorId);
            httpRequest.Method = method;

            if (method != HttpMethod.Post && method != HttpMethod.Put) return httpRequest;

            var objectString = JsonConvert.SerializeObject(payload);
            httpRequest.Content = new StringContent(objectString, Encoding.UTF8, "application/json");

            return httpRequest;
        }

        private async Task<HttpResponseMessage> MakeRequestAsync(HttpMethod method, string resourceUri, object payload,
            CancellationToken token)
        {
            var leadXResourceUri = new Uri($"{Url + ReplaceOrganizationIdMacro(resourceUri)}");
            var requestMessage = PrepareRequest(leadXResourceUri, method, payload);
            var response = await _httpClient.SendAsync(requestMessage, token);

            // Check for Internal Server Error and throw LeadX Custom Exception
            if (response.StatusCode == HttpStatusCode.InternalServerError)
                throw new LeadXInternalServerException("LeadX Internal Server Error", _leadX.OrganizationId,
                    _leadX.Version);

            return response.IsSuccessStatusCode ? response : ThrowLeadXException(response);
        }

        /// <summary>
        /// Throw the LeadX custom exception based on LeadX Error code.
        /// </summary>
        /// <param name="response">Request message.</param>
        private static HttpResponseMessage ThrowLeadXException(HttpResponseMessage response)
        {
            // Enhancement: Create a Package for LeadX Exception and Implement the Exceptions based on Status Code from LeadX API.

            throw new NotImplementedException();
        }

        public async Task<T> ExecuteRequestAsync<T>(
            HttpMethod method,
            string resourceUri,
            object requestBody = null,
            CancellationToken token = default)
        {
            if (method == HttpMethod.Get && requestBody != null)
                throw new ArgumentException("GET request cannot support payload.");

            string jsonString;
            using (var responseMessage = await MakeRequestAsync(method, resourceUri, requestBody, token))
            {
                jsonString = await responseMessage.Content.ReadAsStringAsync();
            }

            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public async Task<JToken> ExecuteRequestAsync(
            HttpMethod method,
            string resourceUri,
            object requestBody = null,
            CancellationToken token = default)
        {
            if (method == HttpMethod.Get && requestBody != null)
                throw new ArgumentException("GET request cannot support payload.");

            string jsonString;
            using (var responseMessage = await MakeRequestAsync(method, resourceUri, requestBody, token))
            {
                jsonString = await responseMessage.Content.ReadAsStringAsync();
            }

            return JObject.Parse(jsonString);
        }

        private string ReplaceOrganizationIdMacro(string resourceUri)
        {
            return resourceUri.Contains(_leadX.Organization.OrganizationMacro)
                ? resourceUri.Replace(_leadX.Organization.OrganizationMacro,
                    _leadX.OrganizationId.ToString())
                : resourceUri;
        }
    }
}
