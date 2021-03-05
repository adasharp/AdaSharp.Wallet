using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class ListWalletRequest : CardanoNodeRequest
    {
        internal override IRestRequest ToRestRequest()
        {
            return new RestRequest("/wallets", Method.GET);
        }

        internal override void Validate()
        { }
    }
}