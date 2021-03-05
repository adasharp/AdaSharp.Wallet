using RestSharp;

namespace AdaSharp.Model.Network
{
    public class GetClockResponse : CardanoNodeResponse
    {
        public Clock Clock { get; set; }

        internal GetClockResponse(IRestResponse responseFromNode)
            : base(GetStatusCodeIn(responseFromNode))
        {
            Clock = new Clock();

            PopulateTo(Clock, responseFromNode);
        }
    }
}