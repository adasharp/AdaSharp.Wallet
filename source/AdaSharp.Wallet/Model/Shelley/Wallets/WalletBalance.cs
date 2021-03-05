using Newtonsoft.Json;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class WalletBalance
    {
        [JsonProperty("available")]
        public UnitOfMeasure Available { get; set; }

        [JsonProperty("reward")]
        public UnitOfMeasure Reward { get; set; }

        [JsonProperty("total")]
        public UnitOfMeasure Total { get; set; }
    }
}