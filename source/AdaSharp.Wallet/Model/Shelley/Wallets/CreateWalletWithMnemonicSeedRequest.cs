using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class CreateWalletWithMnemonicSeedRequest : CreateWalletRequest
    {
        [JsonProperty("mnemonic_sentence")]
        public List<string> MnemonicSentence { get; set; }

        [JsonProperty("mnemonic_second_factor")]
        public List<string> MnemonicSecondFactor { get; set; }

        [JsonProperty("passphrase")]
        public string Passphrase { get; set; }
        
        internal override IRestRequest ToRestRequest()
        {
            Validate();
            

            var restRequest =  new RestRequest("/wallets", Method.POST);

            restRequest.AddJsonBody(this);

            return restRequest;
        }

        internal override void Validate()
        {
            // TODo
        }
    }
}