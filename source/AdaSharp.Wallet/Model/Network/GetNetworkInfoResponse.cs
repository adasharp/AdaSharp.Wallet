using RestSharp;

namespace AdaSharp.Model.Network
{
    public class GetNetworkInfoResponse : CardanoNodeResponse
    {
        public NetworkInfo NetworkInfo { get; set; }

        public GetNetworkInfoResponse(IRestResponse responseFromNode) 
            : base(GetStatusCodeIn(responseFromNode))
        {
            NetworkInfo = new NetworkInfo();

            PopulateTo(NetworkInfo, responseFromNode);
        }
    }
}