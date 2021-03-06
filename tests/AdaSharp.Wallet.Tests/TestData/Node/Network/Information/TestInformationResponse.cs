using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Network.Information
{
    public static class TestInformationResponse
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Network\Information\Http200.json");

        public static IRestResponse Http200SyncStatusIsReady => Http200;

        public static IRestResponse Http200EraIsMary => Http200;

        public static IRestResponse Http406 =>
            TestRestResponse.LoadHttp406From(@"TestData\Node\Network\Information\Http406.json");
    }
}