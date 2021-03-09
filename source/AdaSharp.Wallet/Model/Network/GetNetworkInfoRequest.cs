using RestSharp;

namespace AdaSharp.Model.Network
{
    public class GetNetworkInfoRequest : CardanoNodeRequest
    {
        internal override IRestRequest ToRestRequest()
        {
            Validate();

            return new RestRequest("/network/information", Method.GET);
        }

        internal override void Validate()
        { }
    }
}