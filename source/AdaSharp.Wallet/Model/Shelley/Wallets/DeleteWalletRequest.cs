using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class DeleteWalletRequest : CardanoNodeRequest
    {
        public string WalletId { get; set; }

        internal override IRestRequest ToRestRequest()
        {
            Validate();

            var resourceUri = $"/wallets/{WalletId}";
            var restRequest = new RestRequest(resourceUri, Method.DELETE);

            return restRequest;
        }

        internal override void Validate()
        {
            if (string.IsNullOrWhiteSpace(WalletId))
            {
                throw new InvalidRequestException($"A value for the \"{nameof(WalletId)}\" property is required.");
            }
        }
    }
}