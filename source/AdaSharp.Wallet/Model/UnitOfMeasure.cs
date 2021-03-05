using Newtonsoft.Json;

namespace AdaSharp.Model
{
    public class UnitOfMeasure
    {
        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }

        public UnitOfMeasure() 
        { }

        /// <remarks>
        /// Created specifically to make the unit test code easier to read.
        /// </remarks>
        internal UnitOfMeasure(int quantity, string unit)
        {
            Quantity = quantity;
            Unit = unit;
        }

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
