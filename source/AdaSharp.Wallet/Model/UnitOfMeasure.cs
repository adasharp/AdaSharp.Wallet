using Newtonsoft.Json;

namespace AdaSharp.Model
{
    public class UnitOfMeasure
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        // TODO: Test.
        public override string ToString()
        {
            var includeUnitInOutput = string.IsNullOrWhiteSpace(Unit) == false;

            return includeUnitInOutput
                ? $"{Quantity} {Unit}"
                : $"{Quantity}";
        }
    }
}
