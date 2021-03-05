using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AdaSharp.Model.Shelley.Wallets
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DelegationStatus
    {
        NotInitialized = 0,

        // TODO: Apply to all other enums.
        [EnumMember(Value = "delegating")]
        Delegating = 1,

        [EnumMember(Value = "not_delegating")]
        NotDelegating = 2
    }
}