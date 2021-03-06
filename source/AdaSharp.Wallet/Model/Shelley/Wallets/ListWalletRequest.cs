using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class ListWalletRequest : CardanoNodeRequest
    {
        internal override IRestRequest ToRestRequest()
        {
            Validate();

            return new RestRequest("/wallets", Method.GET);
        }

        protected override void Validate()
        { }
    }
}