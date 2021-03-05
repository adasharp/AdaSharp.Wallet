using AdaSharp.Model.Shelley.Wallets;

namespace AdaSharp.Model.Shelley
{
    public interface IShelleyRestResource
    {
        IWalletRestResource Wallets { get; }
    }
}