using System;
using System.Net;
using AdaSharp.Network;
using AdaSharp.Rest;
using RestSharp;

namespace AdaSharp
{
    public sealed class AdaSharpClient : IAdaSharpClient
    {
        private readonly IRestClientFactory _restClientFactory;

        public CardanoNodeEndpoint CardanoNode { get; }

        public INetworkRestResource Network { get; }

        public AdaSharpClient(CardanoNodeEndpoint node)
            : this(node, InitializeRestClientFactory())
        { }

        internal AdaSharpClient(CardanoNodeEndpoint node, IRestClientFactory restClientFactory)
        {
            _restClientFactory = restClientFactory ?? throw new ArgumentNullException(nameof(restClientFactory));

            Network = new NetworkRestResource(this);
            CardanoNode = node ?? throw new ArgumentNullException(nameof(node));
        }

        public IRestResponse Send(IRestRequest restRequest)
        {
            if (restRequest == null)
            {
                throw new ArgumentNullException(nameof(restRequest));
            }

            var client = InitializeConfiguredClient();

            return client.Execute(restRequest);
        }

        private IRestClient InitializeConfiguredClient()
        {
            // TODO: Configure the client.
            // TODO: SSL support?
            // TODO: Add support for multi-version.
            var client = _restClientFactory.Build();

            client.BaseUrl = CardanoNode.ToUri();
            
            // TODO: StringToEnumConverter here.

            return client;
        }

        private static IRestClientFactory InitializeRestClientFactory()
        {
            return new RestClientFactory();
        }

        
    }
}