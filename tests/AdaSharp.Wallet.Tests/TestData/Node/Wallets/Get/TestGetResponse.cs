using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Wallets.Get
{
    public static class TestGetResponse
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Wallets\Get\Http200.json");
    }
}