using System.Runtime.Serialization;

namespace AdaSharp.Model.Network
{
    public enum ClockStatus
    {
        NotInitialized = 0,

        [EnumMember(Value = "available")]
        Available = 1,

        [EnumMember(Value = "unavailable")]
        Unavailable = 2,

        [EnumMember(Value = "pending")]
        Pending = 3
    }
}