using Newtonsoft.Json;

namespace AdaSharp
{
    public class NodeError
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}