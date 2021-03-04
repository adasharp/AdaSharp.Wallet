using Newtonsoft.Json;

namespace AdaSharp
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
    }
}
