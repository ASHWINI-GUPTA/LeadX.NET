using System;
using LeadX.NET.Entities;
using LeadX.NET.Enum;
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

        private int _organizationId;
        
        private string _vendorId;

        /// <summary>
        /// Gets or sets the API version to interact with.
        /// </summary>
        public string Version { get; set; }

        private LeadX(LeadXCredential credential)
        {
            Credential = credential;
            Version = "1.0";
            Services = new ServiceLocator();
            ConfigureDefaultServices(Services);
        }

        private void ConfigureDefaultServices(ServiceLocator services)
        {
            services.Register<IRestClient>(() => new RestClient(this));
            services.Register<IAuthorizationService>(() => new AuthorizationService(this));
            services.Register<IUserService>(() => new UserService(this));
            services.Register<IOrganizationService>(() => new OrganizationService(this));
            services.Register<ILeadService>(() => new LeadService(this));
        }

        /// <summary>
        /// Gets or sets an LeadX Organization Id.
        /// </summary>
        public int OrganizationId
        {
            get =>
                _organizationId != default
                    ? _organizationId
                    : throw new ArgumentException("Organization Id must be provided.", nameof(OrganizationId));
            set => _organizationId = value;
        }

        /// <summary>
        /// Gets or sets the Vendor Id/Key for an <see cref="OrganizationId"/>.
        /// </summary>
        public string VendorId
        {
            get =>
                string.IsNullOrWhiteSpace(_vendorId)
                    ? throw new ArgumentException("Vendor Id must be provided.", nameof(OrganizationId))
                    : _vendorId;
            set => _vendorId = value;
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
        /// <see cref="Permission.MANAGE_USER"/> is required to access this resource.
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
        
        /// <summary>
        /// Get an object to interact with Lead resource of LeadX for an Organization.
        /// Leads related permission is required to interact with this resource.
        /// </summary>
        public ILeadService Lead => Services.Get<ILeadService>();
    }
}
