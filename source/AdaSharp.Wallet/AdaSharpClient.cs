using System;
using AdaSharp.Network;
using AdaSharp.Rest;
using RestSharp;

namespace AdaSharp
{
    public sealed class AdaSharpClient
    {
        private readonly IRestClientFactory _restClientFactory;

        public CardanoNodeEndpoint CardanoNode { get; }

        public AdaSharpClient(CardanoNodeEndpoint node)
            : this(node, InitializeRestClientFactory())
        { }

        internal AdaSharpClient(CardanoNodeEndpoint node, IRestClientFactory restClientFactory)
        {
            CardanoNode = node ?? throw new ArgumentNullException(nameof(node));
            _restClientFactory = restClientFactory ?? throw new ArgumentNullException(nameof(restClientFactory));
        }

        public GetClockResponse GetClock(GetClockRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseFromNode = Send(request);

            // TODO: Error inspection.

            return new GetClockResponse(responseFromNode);
        }

        public GetNetworkInfoResponse GetNetworkInfo()
        {
            return GetNetworkInfo(new GetNetworkInfoRequest());
        }

        public GetNetworkInfoResponse GetNetworkInfo(GetNetworkInfoRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseFromNode = Send(request);

            // TODO: Error inspection.

            return new GetNetworkInfoResponse(responseFromNode);
        }

        private IRestResponse Send(CardanoNodeRequest request)
        {
            request.Validate();

            var requestInRestForm = request.ToRestRequest();

            return Send(requestInRestForm);
        }

        private IRestResponse Send(IRestRequest restRequest)
        {
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