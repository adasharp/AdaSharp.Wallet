using Newtonsoft.Json;

namespace AdaSharp
{
    public class Tip
    {
        [JsonProperty("absolute_slot_number")]
        public int AbsoluteSlotNumber { get; set; }

        [JsonProperty("slot_number")]
        public int SlotNumber { get; set; }

        [JsonProperty("epoch_number")]
        public int EpochNumber { get; set; }

        // TODO: Change data type.
        [JsonProperty("time")]
        public string Time { get; set; }
    }
}