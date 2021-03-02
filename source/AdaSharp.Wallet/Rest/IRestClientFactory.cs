using RestSharp;

namespace AdaSharp.Rest
{
    public interface IRestClientFactory
    {
        IRestClient Build();
    }
}