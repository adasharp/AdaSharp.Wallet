using RestSharp;

namespace AdaSharp.Rest
{
    internal sealed class RestClientFactory : IRestClientFactory
    {
        public IRestClient Build()
        {
            return new RestClient();
        }
    }
}