using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Network.Clock
{
    public static class TestClockResponse
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Network\Clock\Http200.json");

        public static IRestResponse Http200StatusIsAvailable => Http200;

        public static IRestResponse Http200StatusIsPending =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Network\Clock\Http200-StatusIsPending.json");

        public static IRestResponse Http200StatusIsUnavailable =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Network\Clock\Http200-StatusIsUnavailable.json");

        public static IRestResponse Http406 =>
            TestRestResponse.LoadHttp406From(@"TestData\Node\Network\Clock\Http406.json");
    }
}