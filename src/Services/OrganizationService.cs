using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LeadX.NET.Entities;
using LeadX.NET.Interfaces;

namespace LeadX.NET.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly LeadX _leadX;

        public OrganizationService(LeadX leadX)
        {
            _leadX = leadX;
        }

        public string OrganizationMacro => "$LeadXOrganizationId$";

        public async Task<Organization> GetAsync(int organizationId)
        {
            var resourceUri = $"/v{_leadX.Version}/organizations/{organizationId}";
            return await _leadX.RestClient.ExecuteRequestAsync<Organization>(HttpMethod.Get, resourceUri);
        }

        public async Task<IEnumerable<Organization>> GetAsync()
        {
            var resourceUri = $"/v{_leadX.Version}/organizations";
            return await _leadX.RestClient.ExecuteRequestAsync<IEnumerable<Organization>>(HttpMethod.Get, resourceUri);
        }
    }
}
