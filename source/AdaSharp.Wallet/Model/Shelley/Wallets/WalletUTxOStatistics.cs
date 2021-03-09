using Newtonsoft.Json;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class WalletUTxOStatistics
    {
        [JsonProperty("distribution")]
        public UTxODistribution Distribution { get; set; }

        [JsonProperty("scale")]
        public string Scale { get; set; }

        [JsonProperty("total")]
        public UnitOfMeasure Total { get; set; }
    }
}