using Newtonsoft.Json;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class WalletPassphrase
    {
        [JsonProperty("last_updated_at")]
        public string LastUpdatedAt { get; set; }
    }
}