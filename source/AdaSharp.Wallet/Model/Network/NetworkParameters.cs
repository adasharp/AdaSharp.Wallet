using Newtonsoft.Json;

namespace AdaSharp.Model.Network
{
    // TODO: Someone is going to harp on me for plural nouns in a class name.
    public class NetworkParameters
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
    }
}