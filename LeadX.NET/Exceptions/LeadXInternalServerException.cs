using System;
using System.Runtime.Serialization;

namespace LeadX.NET.Exceptions
{
    /// <summary>
    /// Indicates Internal Server Error on LeadX
    /// </summary>
    [Serializable]
    public class LeadXInternalServerException : Exception, ILeadXException
    {
        /// <inheritdoc />
        public int OrganizationId { get; }
        
        /// <inheritdoc />
        public string Version { get; }

        /// <inheritdoc />
        public LeadXInternalServerException(string message, int organizationId, string version) 
            : base(message)
        {
            OrganizationId = organizationId;
            Version = version;
        }

        /// <inheritdoc />
        public LeadXInternalServerException(string message, Exception inner, int organizationId, string version) 
            : base(message, inner)
        {
            OrganizationId = organizationId;
            Version = version;
        }

        protected LeadXInternalServerException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
