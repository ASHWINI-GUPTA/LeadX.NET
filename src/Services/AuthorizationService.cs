using System.Net.Http;
using LeadX.NET.Entities;
using LeadX.NET.Interfaces;

namespace LeadX.NET.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly LeadX _leadX;
        private readonly LeadXCredential _credential;
        private readonly string _resourceUri;
        private string _accessToken;

        public AuthorizationService(LeadX leadX)
        {
            _leadX = leadX;
            _credential = _leadX.Credential;
            _accessToken = _credential.AuthToken;
            _resourceUri = $"/v{_leadX.Version}/authorization";
        }

        public string GetAccessToken()
        {
            if (_accessToken != null) return _accessToken;

            var tokenJObject = _leadX.RestClient.ExecuteRequestAsync(HttpMethod.Post, _resourceUri,
                new {_credential.Username, _credential.Password}).GetAwaiter().GetResult();

            _accessToken = tokenJObject["token"].ToString();
            return _accessToken;
        }
    }
}
