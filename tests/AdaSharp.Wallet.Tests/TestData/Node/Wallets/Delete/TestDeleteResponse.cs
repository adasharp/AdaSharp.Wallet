using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Wallets.Delete
{
    public static class TestDeleteResponse
    {
        public static IRestResponse Http204 =>
            TestRestResponse.LoadHttp204From(@"TestData\Node\Wallets\Delete\Http204.json");
    }
}