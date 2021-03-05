using Newtonsoft.Json;

namespace AdaSharp.Model.Network
{
    public class Clock
    {
        [JsonProperty("status")]
        public ClockStatus Status { get; set; }

        [JsonProperty("offset")]
        public UnitOfMeasure Offset { get; set; }
    }
}