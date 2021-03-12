using AdaSharp.Model.Shelley.Wallets;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    public abstract class CreateOrRestoreWalletRequestTestBase : CardanoNodeRequestTestBase
    {
        protected const string NominalWalletName = "Pied Piper";
        protected const string NominalPassphrase = "radio-on-internet";
        protected const int NominalAddressPoolGap = CreateOrRestoreWalletRequest.DefaultAddressPoolGap;
    }
}