using System;

namespace AdaSharp.Network
{
    public sealed class NetworkRestResource : RestResourceBase, INetworkRestResource
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