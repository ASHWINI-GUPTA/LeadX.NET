using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LeadX.NET.Entities;
using LeadX.NET.Exceptions;
using LeadX.NET.Helpers;
using LeadX.NET.Interfaces;

namespace LeadX.NET.Services
{
    public class LeadService : ILeadService
    {
        private readonly LeadX _leadX;

        public LeadService(LeadX leadX)
        {
            _leadX = leadX;
        }

        /// <inheritdoc />
        public async Task<Lead> GetAsync(int leadId)
        {
            var resourceUri =
                $"/v{_leadX.Version}/organizations/{_leadX.Organization.OrganizationMacro}/leads/{leadId}";
            return await _leadX.RestClient.ExecuteRequestAsync<Lead>(HttpMethod.Get, resourceUri);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<Lead>> GetAsync(LeadQueryParam queryParam)
        {
            var resourceUri = $"/v{_leadX.Version}/organizations/{_leadX.Organization.OrganizationMacro}/leads";

            return await _leadX.RestClient.ExecuteRequestAsync<IEnumerable<Lead>>(HttpMethod.Get,
                resourceUri + RequestHelper.PrepareQueryParams(queryParam));
        }

        /// <inheritdoc />
        public async Task<LeadCount> GetCountAsync(LeadQueryParam queryParam)
        {
            var resourceUri = $"/v{_leadX.Version}/organizations/{_leadX.Organization.OrganizationMacro}/leads/count";

            return await _leadX.RestClient.ExecuteRequestAsync<LeadCount>(HttpMethod.Get,
                resourceUri + RequestHelper.PrepareQueryParams(queryParam));
        }

        /// <inheritdoc />
        public async Task<bool> UpdateStatus(int leadId, int statusId)
        {
            return await UpdateLead(leadId, new {StatusId = statusId});
        }

        /// <inheritdoc />
        public async Task<bool> UpdateSize(int leadId, int sizeId)
        {
            return await UpdateLead(leadId, new {SizeId = sizeId});
        }

        private async Task<bool> UpdateLead(int leadId, object updatePayload)
        {
            var resourceUri =
                $"/v{_leadX.Version}/organizations/{_leadX.Organization.OrganizationMacro}/leads/{leadId}";

            try
            {
                await _leadX.RestClient.ExecuteRequestAsync(HttpMethod.Put, resourceUri, updatePayload);
            }
            catch (LeadXInternalServerException)
            {
                return false;
            }

            return true;
        }
    }
}