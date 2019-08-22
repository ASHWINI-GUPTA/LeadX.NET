namespace LeadX.NET.Interfaces
{
    public interface IAuthorizationService
    {
        /// <summary>
        /// Get the Access Token to interact with LeadX resources.
        /// </summary>
        string GetAccessToken();
    }
}
