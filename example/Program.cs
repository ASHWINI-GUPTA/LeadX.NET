using System;
using System.Threading.Tasks;
using LeadX.NET.Entities;

namespace Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Started...!!!");

            var cred = new LeadXCredential("YOUR ACCESS TOKEN");

            var leadX = LeadX.NET.LeadX.Client(cred);
            leadX.Version = "1.0";
            leadX.OrganizationId = 1;
            leadX.VendorId = "ORGANIZATION VENDOR ID/KEY";

            // Get the current user info
            var currentUser = await leadX.Users.MeAsync();
            Console.WriteLine($"Hello, {currentUser.FirstName}!");
        }
    }
}
