using RestSharp;

namespace AdaSharp.Network
{
    public class GetNetworkParametersRequest : CardanoNodeRequest
    {
        internal override IRestRequest ToRestRequest()
        {
            return new RestRequest("/network/parameters", Method.GET);
        }

        internal override void Validate()
        { }
    }
}