using RestSharp;

namespace AdaSharp.Tests.TestData.Node.Wallets.Statistics.Utxos
{
    public static class TestUtxosResponse
    {
        public static IRestResponse Http200 =>
            TestRestResponse.LoadHttp200From(@"TestData\Node\Wallets\Statistics\Utxos\Http200.json");
    }
}