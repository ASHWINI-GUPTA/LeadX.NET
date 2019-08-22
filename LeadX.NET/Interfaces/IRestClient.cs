using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace LeadX.NET.Interfaces
{
    public interface IRestClient
    {
        /// <summary>
        /// Base url of the LeadX API.
        /// </summary>
        string Url { get; }

        /// <summary>
        /// Executes an async request and serializes the response to an object.
        /// </summary>
        /// <typeparam name="T">Type to serialize the response.</typeparam>
        /// <param name="method">Request method.</param>
        /// <param name="resourceUri">Request resource url.</param>
        /// <param name="requestBody">Request body to be serialized.</param>
        /// <param name="token">Cancellation token for this operation.</param>
        Task<T> ExecuteRequestAsync<T>(HttpMethod method, string resourceUri, object requestBody = null,
            CancellationToken token = default);

        /// <summary>
        /// Executes an async request and returns the response as JSON.
        /// </summary>
        /// <param name="method">Request method.</param>
        /// <param name="resourceUri">Request resource url.</param>
        /// <param name="requestBody">Request body to be serialized.</param>
        /// <param name="token">Cancellation token for the operation.</param>
        Task<JToken> ExecuteRequestAsync(HttpMethod method, string resourceUri, object requestBody = null,
            CancellationToken token = default);
    }
}
