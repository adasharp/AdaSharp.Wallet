using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class CreateOrRestoreWalletResponse : CardanoNodeResponse
    {
        public Wallet Wallet { get; set; }

        public CreateOrRestoreWalletResponse(IRestResponse responseFromNode)
            : base(GetStatusCodeIn(responseFromNode))
        {
            Wallet = new Wallet();

            PopulateTo(Wallet, responseFromNode);
        }
    }
}