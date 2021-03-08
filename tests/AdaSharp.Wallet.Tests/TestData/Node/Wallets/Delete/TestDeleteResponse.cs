using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Wallets.Delete
{
    public static class TestDeleteResponse
    {
        public static IRestResponse Http204 =>
            TestRestResponse.LoadHttp204From(@"TestData\Node\Wallets\Delete\Http204.json");

        public static IRestResponse Http400 =>
            TestRestResponse.LoadHttp400From(@"TestData\Node\Wallets\Delete\Http400.json");

        public static IRestResponse Http404 =>
            TestRestResponse.LoadHttp404From(@"TestData\Node\Wallets\Delete\Http404.json");

        public static IRestResponse Http406 =>
            TestRestResponse.LoadHttp406From(@"TestData\Node\Wallets\Delete\Http406.json");
    }
}