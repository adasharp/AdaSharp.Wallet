using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;

namespace AdaSharp.Model.Shelley.Wallets
{
    public class CreateOrRestoreWalletWithMnemonicSeedRequest : CreateOrRestoreWalletRequest
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
            ValidateName();
            ValidateMnemonicSentence();
            ValidateMnemonicSecondFactor();
            ValidatePassphrase();
        }

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new InvalidRequestException($"A value for the \"{nameof(Name)}\" property is required.");
            }
        }

        private void ValidateMnemonicSentence()
        {
            if (MnemonicSentence == null)
            {
                throw new InvalidRequestException($"The \"{nameof(MnemonicSentence)}\" property cannot be null.");
            }

            if (MnemonicSentence.Count < MnemonicSentenceMetadata.MinNumberOfWords)
            {
                var exceptionMessage =
                    $"The mnemonic sentence must contain at least {MnemonicSentenceMetadata.MinNumberOfWords} words. " +
                    $"Only {MnemonicSentence.Count} word(s) were provided.";

                throw new InvalidRequestException(exceptionMessage);
            }

            if (MnemonicSentence.Count > MnemonicSentenceMetadata.MaxNumberOfWords)
            {
                var exceptionMessage =
                    $"The mnemonic sentence cannot contain more than {MnemonicSentenceMetadata.MaxNumberOfWords} words. " +
                    $"{MnemonicSentence.Count} word(s) were provided.";

                throw new InvalidRequestException(exceptionMessage);
            }
        }

        private void ValidateMnemonicSecondFactor()
        {
            if (MnemonicSecondFactor == null)
            {
                return;
            }

            if (MnemonicSecondFactor.Count < MnemonicSecondFactorMetadata.MinNumberOfWords)
            {
                var exceptionMessage =
                    $"The mnemonic second factor must contain at least {MnemonicSecondFactorMetadata.MinNumberOfWords} " +
                    $"words. Only {MnemonicSecondFactor.Count} word(s) were provided.";

                throw new InvalidRequestException(exceptionMessage);
            }

            if (MnemonicSecondFactor.Count > MnemonicSecondFactorMetadata.MaxNumberOfWords)
            {
                var exceptionMessage =
                    $"The mnemonic second factor cannot contain more than {MnemonicSecondFactorMetadata.MaxNumberOfWords} " +
                    $"words. {MnemonicSecondFactor.Count} word(s) were provided.";

                throw new InvalidRequestException(exceptionMessage);
            }
        }

        private void ValidatePassphrase()
        {
            if (string.IsNullOrWhiteSpace(Passphrase))
            {
                throw new InvalidRequestException($"A value for the \"{nameof(Passphrase)}\" property is required.");
            }

            if (Passphrase.Length < PassphraseMetadata.MinLength)
            {
                var exceptionMessage = 
                    $"The passphrase cannot be less than {PassphraseMetadata.MinLength} characters. " +
                    $"{Passphrase.Length} character(s) were provided.";

                throw new InvalidRequestException(exceptionMessage);
            }

            if (Passphrase.Length > PassphraseMetadata.MaxLength)
            {
                var exceptionMessage =
                    $"The passphrase cannot have more than {PassphraseMetadata.MaxLength} characters. " +
                    $"{Passphrase.Length} character(s) were provided.";

                throw new InvalidRequestException(exceptionMessage);
            }
        }
    }
}