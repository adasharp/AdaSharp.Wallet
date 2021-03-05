using System.Collections.Generic;
using Newtonsoft.Json;

namespace AdaSharp.Shelley.Wallets
{
    // TODO: Could some of the classes be shared between Byron and Shelley wallets?
    public class AssetBalance
    {
        [JsonProperty("available")]
        public List<UnitOfMeasure> Available { get; set; }

        [JsonProperty("total")]
        public List<UnitOfMeasure> Total { get; set; }
    }
}