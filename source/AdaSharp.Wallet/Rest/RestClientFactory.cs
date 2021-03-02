using RestSharp;

namespace AdaSharp.Rest
{
    public sealed class RestClientFactory : IRestClientFactory
    {
        public IRestClient Build()
        {
            return new RestClient();
        }
    }
}