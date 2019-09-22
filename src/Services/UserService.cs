using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LeadX.NET.Entities;
using LeadX.NET.Interfaces;

namespace LeadX.NET.Services
{
    public class UserService : IUserService
    {
        private readonly LeadX _leadX;

        public UserService(LeadX leadX)
        {
            _leadX = leadX;
        }

        public async Task<User> MeAsync()
        {
            var resourceUri = $"/v{_leadX.Version}/me";
            return await _leadX.RestClient.ExecuteRequestAsync<User>(HttpMethod.Get, resourceUri);
        }

        public async Task<User> GetAsync(int userId)
        {
            var resourceUri = $"/v{_leadX.Version}/organizations/{_leadX.Organization.OrganizationMacro}/users/{userId}";
            return await _leadX.RestClient.ExecuteRequestAsync<User>(HttpMethod.Get, resourceUri);
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var resourceUri = $"/v{_leadX.Version}/organizations/{_leadX.Organization.OrganizationMacro}/users/";
            return await _leadX.RestClient.ExecuteRequestAsync<IEnumerable<User>>(HttpMethod.Get, resourceUri);
        }
    }
}
