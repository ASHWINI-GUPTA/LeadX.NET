using System.Collections.Generic;
using System.Threading.Tasks;
using LeadX.NET.Entities;
using LeadX.NET.Enum;

namespace LeadX.NET.Interfaces
{
    public interface ILeadService
    {
        /// <summary>
        /// Get Lead for an organization.
        /// <see cref="Permission.READ_LEAD"/> is required to fetch lead from an organization.
        /// </summary>
        /// <param name="leadId">Lead Id</param>
        /// <returns>Return the <see cref="Lead"/>.</returns>
        Task<Lead> GetAsync(int leadId);

        /// <summary>
        /// Get the Leads for an organization with provided filters.
        /// <see cref="Permission.READ_LEAD"/> is required to fetch leads from an organization.
        /// </summary>
        /// <param name="queryParam">Query parameter to fetch leads.</param>
        /// <returns>Return the collection of <see cref="Lead"/>.</returns>
        Task<IEnumerable<Lead>> GetAsync(LeadQueryParam queryParam);

        /// <summary>
        /// Get the count of Leads for an organization with provided filters.
        /// </summary>
        /// <param name="queryParam">Query parameter to fetch leads.</param>
        /// <returns>Return the count of leads.</returns>
        Task<LeadCount> GetCountAsync(LeadQueryParam queryParam);

        /// <summary>
        /// Update the Lead Status.
        /// <see cref="Permission.EDIT_LEAD_STATUS"/> is required to update lead status in an organization.
        /// </summary>
        /// <param name="leadId">Lead Id to be update.</param>
        /// <param name="statusId">New Status Id need to be updated.</param>
        /// <returns>Return <see cref="bool"/> indicating weather lead is successfully updated or not.</returns>
        Task<bool> UpdateStatus(int leadId, int statusId);

        /// <summary>
        /// Update the Lead Size.
        /// <see cref="Permission.EDIT_LEAD_SIZE"/> is required to update lead size in an organization.
        /// </summary>
        /// <param name="leadId">Lead Id to be update.</param>
        /// <param name="sizeId">New Size Id need to be updated.</param>
        /// <returns>Return <see cref="bool"/> indicating weather lead is successfully updated or not.</returns>
        Task<bool> UpdateSize(int leadId, int sizeId);
    }
}
