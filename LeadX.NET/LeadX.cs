using System;
using LeadX.NET.Entities;
using LeadX.NET.Interfaces;
using LeadX.NET.Services;

namespace LeadX.NET
{
    /// <summary>
    /// Represent the LeadX Client
    /// </summary>
    public class LeadX
    {
        // TODO: Create Cache Service to Cache all kind of Resources.

        internal LeadXCredential Credential { get; }

        private ServiceLocator Services { get; }

        /// <summary>
        /// Gets or sets an LeadX Organization Id.
        /// </summary>
        public int OrganizationId { get; set; }

        /// <summary>
        /// Gets or sets the Vendor Id for an <see cref="OrganizationId"/>.
        /// </summary>
        public string VendorId { get; set; }

        /// <summary>
        /// Gets or sets the API version id.
        /// </summary>
        public int Version { get; set; }

        private LeadX(LeadXCredential credential)
        {
            OrganizationId = default;
            VendorId = default;
            Credential = credential;
            Version = 1;
            Services = new ServiceLocator();
            ConfigureDefaultServices(Services);
        }

        private void ConfigureDefaultServices(ServiceLocator services)
        {
            services.Register<IAuthorizationService>(() => new AuthorizationService(this));
            services.Register<IUserService>(() => new UserService(this));
            services.Register<IOrganizationService>(() => new OrganizationService(this));
            services.Register<IRestClient>(() => new RestClient(this));
        }

        public static LeadX Client(LeadXCredential credential)
        {
            return new LeadX(credential);
        }


        /// <summary>
        /// Get an object to make a request to LeadX.
        /// </summary>
        public IRestClient RestClient => Services.Get<IRestClient>();

        /// <summary>
        /// Get an object to interact with Users resource of LeadX.
        /// MANAGE_USER permission is required to access this resource.
        /// </summary>
        public IUserService Users => Services.Get<IUserService>();

        /// <summary>
        /// Get an object to interact with LeadX authentication.
        /// </summary>
        public IAuthorizationService Authorization => Services.Get<IAuthorizationService>();

        /// <summary>
        /// Get an object to interact with Organization resource of LeadX.
        /// User must have access to the requested organization.
        /// </summary>
        public IOrganizationService Organization => Services.Get<IOrganizationService>();
    }
}
