using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class CreateWalletResponse : CardanoNodeResponse
    {
        public Wallet Wallet { get; set; }

        public CreateWalletResponse(IRestResponse responseFromNode)
            : base(GetStatusCodeIn(responseFromNode))
        {
            Wallet = new Wallet();

            Populate(Wallet, responseFromNode);
        }
    }
}