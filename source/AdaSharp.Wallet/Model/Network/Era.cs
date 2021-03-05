using System.Runtime.Serialization;

namespace AdaSharp.Model.Network
{
    // TODO: Sort eras in sequence - because someone will make a comment in the future.
    public enum Era
    {
        NotInitialized = 0,
        
        [EnumMember(Value = "byron")]
        Byron = 1,

        [EnumMember(Value = "allegra")]
        Allegra = 2,
        
        [EnumMember(Value = "shelley")]
        Shelley = 3,

        [EnumMember(Value = "mary")]
        Mary = 4
    }
}