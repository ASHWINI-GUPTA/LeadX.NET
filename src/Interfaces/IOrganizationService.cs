using System.Collections.Generic;
using System.Threading.Tasks;
using LeadX.NET.Entities;

namespace LeadX.NET.Interfaces
{
    /// <summary>
    /// Contain organization related resources.
    /// </summary>
    public interface IOrganizationService
    {
        /// <summary>
        /// Gets the Macro Name for Organization
        /// </summary>
        string OrganizationMacro { get; }

        /// <summary>
        /// Get all LeadX organization for a user.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Organization>> GetAsync();

        /// <summary>
        /// Get organization by id.
        /// </summary>
        /// <param name="organizationId">Organization Id</param>
        Task<Organization> GetAsync(int organizationId);
    }
}
