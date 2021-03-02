using RestSharp;

namespace AdaSharp.Network
{
    public class GetNetworkInfoRequest : CardanoNodeRequest
    {
        internal override IRestRequest ToRestRequest()
        {
            return new RestRequest("/network/information", Method.GET);
        }

        internal override void Validate()
        { }
    }
}