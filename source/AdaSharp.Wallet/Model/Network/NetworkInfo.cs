using Newtonsoft.Json;

namespace AdaSharp.Model.Network
{
    public class NetworkInfo
    {
        [JsonProperty("sync_progress")]
        public SyncState SyncProgress { get; set; }

        [JsonProperty("node_tip")]
        public TipWithHeight NodeTip { get; set; }

        [JsonProperty("network_tip")]
        public Tip NetworkTip { get; set; }

        [JsonProperty("next_epoch")]
        public Epoch NextEpoch { get; set; }

        [JsonProperty("node_era")]
        public Era NodeEra { get; set; }
    }
}