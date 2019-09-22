namespace LeadX.NET.Exceptions
{
    /// <summary>
    /// Define the structure for an LeadX Exception Class
    /// </summary>
    public interface ILeadXException
    {
        /// <summary>
        /// Gets the Organization Id for an Exception.
        /// </summary>
        int OrganizationId { get; }

        /// <summary>
        /// Gets the Version Number for an Exception
        /// </summary>
        string Version { get; }
    }
}
