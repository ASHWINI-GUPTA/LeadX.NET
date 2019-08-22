using System;

namespace LeadX.NET.Entities
{
    /// <summary>
    /// Holds Token information for user that connects to LeadX.
    /// </summary>
    public class LeadXCredential
    {
        public LeadXCredential(string email, string password)
        {
            Username = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public LeadXCredential(string authToken)
        {
            AuthToken = authToken ?? throw new ArgumentNullException(nameof(authToken));
        }

        internal string Username { get; }
        internal string Password { get; }
        internal string AuthToken { get; }
    }
}
