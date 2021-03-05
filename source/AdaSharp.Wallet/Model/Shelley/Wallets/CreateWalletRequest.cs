using Newtonsoft.Json;

namespace AdaSharp.Model.Shelley.Wallets
{
    public abstract class CreateWalletRequest : CardanoNodeRequest
    {
        public const int DefaultAddressPoolGap = 20;

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address_pool_gap")]
        public int? AddressPoolGap { get; set; }
    }
}