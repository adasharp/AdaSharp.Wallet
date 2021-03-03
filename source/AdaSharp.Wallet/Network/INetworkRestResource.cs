namespace AdaSharp.Network
{
    public interface INetworkRestResource
    {
        GetNetworkInfoResponse GetNetworkInfo();

        GetNetworkInfoResponse GetNetworkInfo(GetNetworkInfoRequest request);

        GetClockResponse GetClock(GetClockRequest request);
    }
}