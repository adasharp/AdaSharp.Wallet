using System;

namespace AdaSharp.Network
{
    internal sealed class NetworkRestResource : RestResourceBase, INetworkRestResource
    {
        internal NetworkRestResource(IAdaSharpClient client)
            : base(client)
        { }

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

            ValidateOkWasReturned(responseFromNode);

            return new GetNetworkInfoResponse(responseFromNode);
        }

        public GetNetworkParametersResponse GetNetworkParameters()
        {
            return GetNetworkParameters(new GetNetworkParametersRequest());
        }

        public GetNetworkParametersResponse GetNetworkParameters(GetNetworkParametersRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseFromNode = Send(request);

            ValidateOkWasReturned(responseFromNode);

            return new GetNetworkParametersResponse(responseFromNode);
        }

        public GetClockResponse GetClock(GetClockRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseFromNode = Send(request);

            ValidateOkWasReturned(responseFromNode);

            return new GetClockResponse(responseFromNode);
        }
    }
}