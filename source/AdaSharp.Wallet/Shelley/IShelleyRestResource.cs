using AdaSharp.Shelley.Wallets;

namespace AdaSharp.Shelley
{
    public interface IShelleyRestResource
    {
        IWalletRestResource Wallets { get; }
    }
}