using Newtonsoft.Json;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class Delegation
    {
        [JsonProperty("status")]
        public DelegationStatus Status { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }
    }
}