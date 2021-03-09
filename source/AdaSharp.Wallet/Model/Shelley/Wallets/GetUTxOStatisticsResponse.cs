using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class GetUTxOStatisticsResponse : CardanoNodeResponse
    {
        public WalletUTxOStatistics Statistics { get; set; }

        public GetUTxOStatisticsResponse(IRestResponse responseFromNode)
            : base(GetStatusCodeIn(responseFromNode))
        {
            Statistics = new WalletUTxOStatistics();
            PopulateTo(Statistics, responseFromNode);
        }
    }
}