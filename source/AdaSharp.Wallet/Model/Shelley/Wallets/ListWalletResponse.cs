using System.Collections.Generic;
using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class ListWalletResponse : CardanoNodeResponse
    {
        public List<Wallet> Wallets { get; set; }

        public ListWalletResponse(IRestResponse responseFromNode) 
            : base(GetStatusCodeIn(responseFromNode))
        {
            Wallets = new List<Wallet>();

            Populate(Wallets, responseFromNode);
        }
    }
}