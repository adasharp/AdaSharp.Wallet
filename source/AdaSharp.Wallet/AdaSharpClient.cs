using System;
using AdaSharp.Model;
using AdaSharp.Model.Network;
using AdaSharp.Model.Shelley;
using AdaSharp.Rest;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace AdaSharp
{
    public sealed class AdaSharpClient : IAdaSharpClient
    {
        private readonly IRestClientFactory _restClientFactory;

        public CardanoNodeEndpoint CardanoNode { get; }

        public INetworkRestResource Network { get; }
        public IShelleyRestResource Shelley { get; }

        public AdaSharpClient(CardanoNodeEndpoint node)
            : this(node, InitializeRestClientFactory())
        { }

        public AdaSharpClient(CardanoNodeEndpoint node, IRestClientFactory restClientFactory)
        {
            _restClientFactory = restClientFactory ?? throw new ArgumentNullException(nameof(restClientFactory));

            Network = new NetworkRestResource(this);
            Shelley = new ShelleyRestResource(this);
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
            

            var jsonSettings = new JsonSerializerSettings();

            jsonSettings.Converters.Add(new StringEnumConverter());

            client.UseNewtonsoftJson(jsonSettings);
            // TODO: StringToEnumConverter here.

            return client;
        }

        private static IRestClientFactory InitializeRestClientFactory()
        {
            return new RestClientFactory();
        }

        
    }
}