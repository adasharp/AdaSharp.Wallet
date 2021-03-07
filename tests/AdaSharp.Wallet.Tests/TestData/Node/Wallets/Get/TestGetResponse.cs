using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Wallets.Get
{
    public static class TestGetResponse
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Wallets\Get\Http200.json");

        public static IRestResponse Http200WalletIsDelegatingAndHasNoNextDelegation => Http200;

        public static IRestResponse Http404 =>
            TestRestResponse.LoadHttp404From(@"TestData\Node\Wallets\Get\Http404.json");

        public static IRestResponse Http400 =>
            TestRestResponse.LoadHttp404From(@"TestData\Node\Wallets\Get\Http400.json");

        public static IRestResponse Http406 =>
            TestRestResponse.LoadHttp404From(@"TestData\Node\Wallets\Get\Http406.json");
    }
}