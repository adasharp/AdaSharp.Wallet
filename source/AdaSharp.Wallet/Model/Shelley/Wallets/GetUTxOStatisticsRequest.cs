using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class GetUTxOStatisticsRequest : CardanoNodeRequest
    {
        public string WalletId { get; set; }

        internal override IRestRequest ToRestRequest()
        {
            Validate();

            var resourceUri = $"/wallets/{WalletId}/statistics/utxos";
            var restRequest = new RestRequest(resourceUri, Method.GET);

            return restRequest;
        }

        internal override void Validate()
        {
            
        }
    }
}