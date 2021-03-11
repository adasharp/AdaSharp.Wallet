using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Wallets.Statistics.Utxos
{
    public static class TestUtxosResponse
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Wallets\Statistics\Utxos\Http200.json");

        public static IRestResponse Http404 =>
            TestRestResponse.LoadHttp404From(@"TestData\Node\Wallets\Statistics\Utxos\Http404.json");

        public static IRestResponse Http406 =>
            TestRestResponse.LoadHttp406From(@"TestData\Node\Wallets\Statistics\Utxos\Http406.json");
    }
}