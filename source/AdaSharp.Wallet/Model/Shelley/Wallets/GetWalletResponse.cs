using System.Net;
using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class GetWalletResponse : CardanoNodeResponse
    {
        public Wallet Wallet { get; set; }

        public GetWalletResponse(IRestResponse responseFromNode)
            : base(GetStatusCodeIn(responseFromNode))
        {
            Wallet = new Wallet();
            PopulateTo(Wallet, responseFromNode);
        }
    }
}