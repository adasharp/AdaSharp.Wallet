using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Wallets.List
{
    public static class TestListResponse
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Wallets\List\Http200.json");
    }
}