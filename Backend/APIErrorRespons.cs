using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IntuneAssignments.Backend
{
    public class ApiErrorResponse
    {
        [JsonProperty("_version")]
        public int Version { get; set; }

        [JsonProperty("Message")]
        public string Message { get; set; }

        [JsonProperty("CustomApiErrorPhrase")]
        public string CustomApiErrorPhrase { get; set; }

        [JsonProperty("RetryAfter")]
        public string RetryAfter { get; set; }

        [JsonProperty("ErrorSourceService")]
        public string ErrorSourceService { get; set; }

        [JsonProperty("HttpHeaders")]
        public string HttpHeaders { get; set; }
    }
}
