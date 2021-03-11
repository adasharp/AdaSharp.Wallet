﻿namespace AdaSharp.Model.Shelley.Wallets
{
    public interface IWalletRestResource
    {
        // TODO: Create Or Restore
        CreateWalletResponse CreateWallet(CreateWalletRequest request);

        ListWalletResponse GetAll(ListWalletRequest request);

        ListWalletResponse GetAll();

        GetWalletResponse GetWallet(GetWalletRequest request);

        DeleteWalletResponse DeleteWallet(DeleteWalletRequest request);

        GetUTxOStatisticsResponse GetUTxOStatistics(GetUTxOStatisticsRequest request);
    }
}