using System.Collections.Generic;
using System.Threading.Tasks;
using LeadX.NET.Entities;

namespace LeadX.NET.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Get the details of current login user.
        /// </summary>
        Task<User> MeAsync();

        /// <summary>
        /// Get the user detail by id.
        /// </summary>
        /// <param name="userId">User Id</param>
        Task<User> GetAsync(int userId);

        /// <summary>
        /// Get all users for an organization.
        /// </summary>
        Task<IEnumerable<User>> GetAsync();
    }
}
