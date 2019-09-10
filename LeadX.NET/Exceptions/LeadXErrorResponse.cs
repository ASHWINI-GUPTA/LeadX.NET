using Newtonsoft.Json;

namespace LeadX.NET.Exceptions
{
    public class LeadXErrorResponse
    {

        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode { get; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; }
    }
}
