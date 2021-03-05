using AdaSharp.Model.Shelley.Wallets;

namespace AdaSharp.Model.Shelley
{
    internal sealed class ShelleyRestResource : RestResourceBase, IShelleyRestResource
    {
        public IWalletRestResource Wallets { get; }

        internal ShelleyRestResource(IAdaSharpClient client)
            : base(client)
        {
            Wallets = new WalletRestResource(client);
        }
    }
}