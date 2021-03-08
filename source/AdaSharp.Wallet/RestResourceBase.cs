using System;
using System.Net;
using AdaSharp.Model;
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
            var requestInRestForm = request.ToRestRequest();

            return _client.Send(requestInRestForm);
        }

        protected static void ValidateOkWasReturned(IRestResponse responseFromNode)
        {
            ValidateSuccessIn(responseFromNode, HttpStatusCode.OK);
        }

        protected static void ValidateNoContentWasReturned(IRestResponse responseFromNode)
        {
            ValidateSuccessIn(responseFromNode, HttpStatusCode.NoContent);
        }

        private static void ValidateSuccessIn(IRestResponse responseFromNode, HttpStatusCode successStatusCode)
        {
            if (responseFromNode.StatusCode != successStatusCode)
            {
                throw ErrorReturnedFromNode(responseFromNode);
            }
        }

        protected static CardanoNodeException ErrorReturnedFromNode(IRestResponse responseFromNode)
        {
            // TODO: We ended up here once because we forgot to set the StatusCode in the test response and 
            // the nodeError was null. A NullRefEx was thrown but that's not good enough. Lets do a 
            // proper verification.
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