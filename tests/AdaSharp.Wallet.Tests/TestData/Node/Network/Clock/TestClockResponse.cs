using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Network.Clock
{
    public static class TestClockResponse
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Network\Clock\Http200.json");

        public static IRestResponse Http406 =>
            TestRestResponse.LoadHttp406From(@"TestData\Node\Network\Clock\Http406.json");
    }
}