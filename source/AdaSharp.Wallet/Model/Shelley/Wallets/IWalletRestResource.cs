namespace AdaSharp.Model.Shelley.Wallets
{
    public interface IWalletRestResource
    {
        CreateWalletResponse CreateWallet(CreateWalletRequest request);

        ListWalletResponse GetAll(ListWalletRequest request);

        ListWalletResponse GetAll();
    }
}