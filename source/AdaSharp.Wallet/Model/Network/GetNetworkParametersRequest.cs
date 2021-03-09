using RestSharp;

namespace AdaSharp.Model.Network
{
    public class GetNetworkParametersRequest : CardanoNodeRequest
    {
        internal override IRestRequest ToRestRequest()
        {
            Validate();

            return new RestRequest("/network/parameters", Method.GET);
        }

        internal override void Validate()
        { }
    }
}