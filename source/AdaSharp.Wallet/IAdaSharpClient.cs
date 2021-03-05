using AdaSharp.Network;
using AdaSharp.Shelley;
using RestSharp;

namespace AdaSharp
{
    public interface IAdaSharpClient
    {
        CardanoNodeEndpoint CardanoNode { get; }
        INetworkRestResource Network { get; }
        IShelleyRestResource Shelley { get; }
        IRestResponse Send(IRestRequest restRequest);
    }
}