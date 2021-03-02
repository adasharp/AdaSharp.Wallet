using Newtonsoft.Json;

namespace AdaSharp.Network
{
    public class NetworkSyncProgress
    {
        [JsonProperty("status")]
        public NetworkSyncStatus Status { get; set; }

        [JsonProperty("progress")]
        public UnitOfMeasure Progress { get; set; }
    }
}