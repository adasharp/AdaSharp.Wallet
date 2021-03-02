using Newtonsoft.Json;
using RestSharp;

namespace AdaSharp.Network
{
    public class GetNetworkInfoResponse : CardanoNodeResponse
    {
        [JsonProperty("sync_progress")]
        public NetworkSyncProgress SyncProgress { get; set; }

        [JsonProperty("node_tip")]
        public TipWithHeight NodeTip { get; set; }

        [JsonProperty("network_tip")]
        public Tip NetworkTip { get; set; }

        [JsonProperty("next_epoch")]
        public Epoch NextEpoch { get; set; }
        
        [JsonProperty("node_era")]
        public Era NodeEra { get; set; }

        public GetNetworkInfoResponse(IRestResponse responseFromNode) 
            : base(GetStatusCodeIn(responseFromNode))
        {
            PopulateSelfWith(responseFromNode);
        }
    }
}