using RestSharp;

namespace AdaSharp.Model.Network
{
    public class GetNetworkParametersResponse : CardanoNodeResponse
    {
        public NetworkParameters NetworkParameters { get; set; }

        public GetNetworkParametersResponse(IRestResponse responseFromNode) 
            : base(GetStatusCodeIn(responseFromNode))
        {
            NetworkParameters = new NetworkParameters();

            PopulateTo(NetworkParameters, responseFromNode);
        }
    }
}