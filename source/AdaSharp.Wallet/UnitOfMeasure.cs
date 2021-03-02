using Newtonsoft.Json;

namespace AdaSharp
{
    public class UnitOfMeasure
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
