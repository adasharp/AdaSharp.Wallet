using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Network.Parameters
{
    public static class TestParametersResponse
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Network\Parameters\Http200.json");

        public static IRestResponse Http406 =>
            TestRestResponse.LoadHttp406From(@"TestData\Node\Network\Parameters\Http406.json");
    }
}