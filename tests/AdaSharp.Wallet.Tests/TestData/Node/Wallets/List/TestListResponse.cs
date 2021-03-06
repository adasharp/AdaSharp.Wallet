using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Wallets.List
{
    public static class TestListResponse
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Wallets\List\Http200.json");

        public static IRestResponse Http200NoWallets =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Wallets\List\Http200-NoWallets.json");

        public static IRestResponse Http406 =>
            TestRestResponse.LoadHttp406From(@"TestData\Node\Wallets\List\Http406.json");
    }
}