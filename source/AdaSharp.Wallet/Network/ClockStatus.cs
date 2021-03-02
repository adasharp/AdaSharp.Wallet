using Newtonsoft.Json;

namespace AdaSharp.Network
{
    public enum ClockStatus
    {
        NotInitialized = 0,

        [JsonProperty("available")]
        Available = 1,

        [JsonProperty("unavailable")]
        Unavailable = 2,

        [JsonProperty("pending")]
        Pending = 3
    }
}