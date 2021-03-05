using Newtonsoft.Json;

namespace AdaSharp.Shelley.Wallets
{
    public class Wallet
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("address_pool_gap")]
        public int AddressPoolGap { get; set; }

        [JsonProperty("balance")]
        public WalletBalance Balance { get; set; }

        [JsonProperty("delegation")]
        public WalletDelegationSettings Delegation { get; set; }

        [JsonProperty("assets")]
        public AssetBalance Assets { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("passphrase")]
        public WalletPassphrase Passphrase { get; set; }

        [JsonProperty("state")]
        public SyncState State { get; set; }

        [JsonProperty("tip")]
        public TipWithHeight Tip { get; set; }
    }
}