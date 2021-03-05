using RestSharp;

namespace AdaSharp.Shelley.Wallets
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