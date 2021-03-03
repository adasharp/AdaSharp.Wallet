using AdaSharp.Network;
using RestSharp;

namespace AdaSharp
{
    public interface IAdaSharpClient
    {
        CardanoNodeEndpoint CardanoNode { get; }
        INetworkRestResource Network { get; }
        IRestResponse Send(IRestRequest restRequest);
    }
}