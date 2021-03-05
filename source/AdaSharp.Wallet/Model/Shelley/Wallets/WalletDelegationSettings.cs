using System.Collections.Generic;
using Newtonsoft.Json;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class WalletDelegationSettings
    {
        [JsonProperty("active")]
        public Delegation Active { get; set; }

        [JsonProperty("next")]
        public List<DelegationChange> Next { get; set; }
    }
}