using Newtonsoft.Json;

namespace AdaSharp.Network
{
    public enum NetworkSyncStatus
    {
        NotInitialized = 0,

        [JsonProperty("ready")]
        Ready = 1,

        [JsonProperty("syncing")]
        Syncing = 2,

        [JsonProperty("not_responding")]
        NotResponding = 3
    }
}