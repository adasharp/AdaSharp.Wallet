using Newtonsoft.Json;

namespace AdaSharp.Shelley.Wallets
{
    public class DelegationChange : Delegation
    {
        [JsonProperty("changes_at")]
        public Epoch ChangesAt { get; set; }
    }
}