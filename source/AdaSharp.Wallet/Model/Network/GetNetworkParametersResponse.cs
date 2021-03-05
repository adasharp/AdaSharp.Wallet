using Newtonsoft.Json;
using RestSharp;

namespace AdaSharp.Model.Network
{
    public class GetNetworkParametersResponse : CardanoNodeResponse
    {
        [JsonProperty("genesis_block_hash")]
        public string GenesisBlockHash { get; set; }

        [JsonProperty("blockchain_start_time")]
        public string BlockchainStartTime { get; set; }

        [JsonProperty("slot_length")]
        public UnitOfMeasure SlotLength { get; set; }

        [JsonProperty("epoch_length")]
        public UnitOfMeasure EpochLength { get; set; }

        [JsonProperty("security_parameter")]
        public UnitOfMeasure SecurityParameter { get; set; }

        [JsonProperty("active_slot_coefficient")]
        public UnitOfMeasure ActiveSlotCoefficient { get; set; }

        [JsonProperty("decentralization_level")]
        public UnitOfMeasure DecentralizationLevel { get; set; }

        [JsonProperty("desired_pool_number")]
        public int DesiredPoolNumber { get; set; }

        [JsonProperty("minimum_utxo_value")]
        public UnitOfMeasure MinimumUtxoValue { get; set; }

        [JsonProperty("eras")]
        public EraEpochDictionary Eras { get; set; }

        public GetNetworkParametersResponse(IRestResponse responseFromNode) 
            : base(GetStatusCodeIn(responseFromNode))
        {
            PopulateSelfWith(responseFromNode);
        }
    }
}