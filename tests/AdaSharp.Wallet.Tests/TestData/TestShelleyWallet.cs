using AdaSharp.Model.Shelley.Wallets;

namespace AdaSharp.Tests.TestData
{
    public static class TestShelleyWallet
    {
        public static Wallet NominalWallet => TestFile.LoadFrom<Wallet>(@"TestData\ShelleyWallet-6b134a8.json");
    }
}