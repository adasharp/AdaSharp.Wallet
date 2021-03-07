using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class DeleteWalletResponse : CardanoNodeResponse
    {
        public DeleteWalletResponse(IRestResponse responseFromNode) 
            : base(GetStatusCodeIn(responseFromNode))
        { }
    }
}