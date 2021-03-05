using System;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace AdaSharp
{
    // TODO: Should this belong in the "Rest" namespace?
    public abstract class RestResourceBase
    {
        private readonly IAdaSharpClient _client;

        protected RestResourceBase(IAdaSharpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        protected IRestResponse Send(CardanoNodeRequest request)
        {
            request.Validate();

            var requestInRestForm = request.ToRestRequest();

            return _client.Send(requestInRestForm);
        }

        protected static void ValidateOkWasReturned(IRestResponse responseFromNode)
        {
            if (IsOk(responseFromNode) == false)
            {
                throw ErrorReturnedFromNode(responseFromNode);
            }
        }

        protected static CardanoNodeException ErrorReturnedFromNode(IRestResponse responseFromNode)
        {
            var nodeError = ParseErrorFromNodeIn(responseFromNode);

            return new CardanoNodeException(nodeError.Code, nodeError.Message, responseFromNode.StatusCode);
        }

        protected static NodeError ParseErrorFromNodeIn(IRestResponse responseFromNode)
        {
            return JsonConvert.DeserializeObject<NodeError>(responseFromNode.Content);
        }

        protected static bool IsOk(IRestResponse responseFromNode)
        {
            return responseFromNode.StatusCode == HttpStatusCode.OK;
        }
    }
}