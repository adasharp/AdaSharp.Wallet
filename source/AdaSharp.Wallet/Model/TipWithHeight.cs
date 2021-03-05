using Newtonsoft.Json;

namespace AdaSharp.Model
{
    public class TipWithHeight : Tip
    {
        [JsonProperty("height")]
        public UnitOfMeasure Height { get; set; }
    }
}