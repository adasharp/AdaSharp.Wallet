using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdaSharp.Network
{
    public enum ClockStatus
    {
        NotInitialized = 0,

        [JsonProperty("available")]
        [JsonConverter(typeof(StringEnumConverter))]
        Available = 1,

        [JsonProperty("unavailable")]
        [JsonConverter(typeof(StringEnumConverter))]
        Unavailable = 2,

        [JsonProperty("pending")]
        [JsonConverter(typeof(StringEnumConverter))]
        Pending = 3
    }
}