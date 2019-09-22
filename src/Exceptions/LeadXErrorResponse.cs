using System.Collections.Generic;
using Newtonsoft.Json;

namespace LeadX.NET.Exceptions
{
    public class LeadXErrorResponse
    {
        [JsonProperty(PropertyName = "errorCode")]
        public string ErrorCode { get; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; }
        
        [JsonProperty(PropertyName = "validationError")]
        public IEnumerable<ValidationError> ValidationErrors { get; set; }
    }

    public class ValidationError
    {
        public string Parameter { get; set; }
        public string Message { get; set; }
    }
} 
