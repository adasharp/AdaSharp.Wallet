using System.Runtime.Serialization;

namespace AdaSharp
{
    public enum SyncStatus
    {
        NotInitialized = 0,

        [EnumMember(Value = "ready")]
        Ready = 1,

        [EnumMember(Value = "syncing")]
        Syncing = 2,

        [EnumMember(Value = "not_responding")]
        NotResponding = 3
    }
}