using Newtonsoft.Json;
using RestSharp;

namespace AdaSharp.Model.Network
{
    public class GetClockResponse : CardanoNodeResponse
    {
        [JsonProperty("status")]
        public ClockStatus Status { get; set; }

        [JsonProperty("offset")]
        public UnitOfMeasure Offset { get; set; }

        internal GetClockResponse(IRestResponse responseFromNode)
            : base(GetStatusCodeIn(responseFromNode))
        {
            PopulateSelfWith(responseFromNode);
        }
    }
}