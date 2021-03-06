using System;

namespace AdaSharp.Model.Shelley.Wallets
{
    internal sealed class WalletRestResource : RestResourceBase, IWalletRestResource
    {
        internal WalletRestResource(IAdaSharpClient client)
            : base(client)
        { }

        public CreateWalletResponse CreateWallet(CreateWalletRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var responseFromNode = Send(request);

            // TODO: validate
            return new CreateWalletResponse(responseFromNode);
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
    }
}