using System.Collections.Generic;
using System.Net;
using RestSharp;

namespace AdaSharp.Shelley.Wallets
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