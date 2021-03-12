using System;

namespace AdaSharp.Model.Shelley.Wallets
{
    internal sealed class WalletRestResource : RestResourceBase, IWalletRestResource
    {
        internal WalletRestResource(IAdaSharpClient client)
            : base(client)
        { }

        public CreateOrRestoreWalletResponse CreateWallet(CreateOrRestoreWalletRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseFromNode = Send(request);

            // TODO: validate
            return new CreateOrRestoreWalletResponse(responseFromNode);
        }

        public ListWalletResponse GetAll(ListWalletRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseFromNode = Send(request);

            ValidateOkWasReturned(responseFromNode);
            
            return new ListWalletResponse(responseFromNode);
        }

        public ListWalletResponse GetAll()
        {
            return GetAll(new ListWalletRequest());
        }

        public GetWalletResponse GetWallet(GetWalletRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseFromNode = Send(request);

            ValidateOkWasReturned(responseFromNode);

            return new GetWalletResponse(responseFromNode);
        }

        public DeleteWalletResponse DeleteWallet(DeleteWalletRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseFromNode = Send(request);

            ValidateNoContentWasReturned(responseFromNode);

            return new DeleteWalletResponse(responseFromNode);
        }

        public GetUTxOStatisticsResponse GetUTxOStatistics(GetUTxOStatisticsRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseFromNode = Send(request);

            ValidateOkWasReturned(responseFromNode);

            return new GetUTxOStatisticsResponse(responseFromNode);
        }
    }
}