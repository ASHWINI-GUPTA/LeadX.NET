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

            var cred = new LeadXCredential("Your LeadX Access Token");

            var leadX = LeadX.NET.LeadX.Client(cred);
            leadX.Version = "1.0";

            var org = await leadX.Organization.GetAsync();

        }
    }
}
