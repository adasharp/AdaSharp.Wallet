using Newtonsoft.Json;

namespace AdaSharp.Model
{
    // TODO: Not a fan of the name. We have SyncState and SyncStatus and they 
    // are fairly similar.
    public class SyncState
    {
        [JsonProperty("status")]
        public SyncStatus Status { get; set; }

        [JsonProperty("progress")]
        public UnitOfMeasure Progress { get; set; }
    }
}