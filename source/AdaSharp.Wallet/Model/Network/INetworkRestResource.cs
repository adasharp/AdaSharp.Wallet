namespace AdaSharp.Model.Network
{
    public interface INetworkRestResource
    {
        GetNetworkInfoResponse GetNetworkInfo();

        GetNetworkInfoResponse GetNetworkInfo(GetNetworkInfoRequest request);

        GetNetworkParametersResponse GetNetworkParameters();

        GetNetworkParametersResponse GetNetworkParameters(GetNetworkParametersRequest request);

        GetClockResponse GetClock(GetClockRequest request);
    }
}