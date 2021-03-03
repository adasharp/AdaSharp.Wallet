using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Network.Information
{
    public static class TestInformation
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Network\Information\Http200.json");

        public static IRestResponse Http200SyncStatusIsReady => Http200;
    }
}