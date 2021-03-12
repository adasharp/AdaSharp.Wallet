using System.Collections.Generic;
using AdaSharp.Model.Shelley.Wallets;
using AdaSharp.Tests.Extensions;
using AdaSharp.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace AdaSharp.Tests.Model.Shelley.Wallets
{
    [TestClass]
    public class CreateOrRestoreWalletWithMnemonicSeedRequestTest : CreateOrRestoreWalletRequestTestBase
    {
        protected static List<string> NominalMnemonicSentence => TestMnemonicSeed.NominalSentence;
        protected static List<string> NominalSecondFactor => TestMnemonicSeed.NominalSecondFactor;

        [TestMethod]
        public void ToRestRequest_RequestIsNotNull_ResourceInRequestIsPopulatedWithCorrectUri()
        {
            // Assemble
            var expectedResourcePath = "/wallets";

            var request = CreateNominalRequest();

            // Act
            var result = request.ToRestRequest();

            // Assert
            Assert.AreEqual(expectedResourcePath, result.Resource);
        }

        [TestMethod]
        public void ToRestRequest_RequestIsNotNull_MethodInRequestIsPost()
        {
            // Assemble
            const Method expectedMethod = Method.POST;

            var request = CreateNominalRequest();

            // Act
            var result = request.ToRestRequest();

            // Assert
            Assert.AreEqual(expectedMethod, result.Method);
        }

        [TestMethod]
        public void ToRestRequest_NameIsNull_ThrowInvalidRequestException()
        {
            // Assemble
            const string exceptionExceptionMessage = "A value for the \"Name\" property is required.";

            var request = CreateNominalRequest();

            request.Name = null;
            
            // Act & Assert
            TestInvalidRequestExceptionIsThrownOn(() => request.ToRestRequest(), exceptionExceptionMessage);
        }

        [TestMethod]
        public void ToRestRequest_MnemonicSentenceIsNull_ThrowInvalidRequestException()
        {
            // Assemble
            const string exceptionExceptionMessage = "The \"MnemonicSentence\" property cannot be null.";

            var request = CreateNominalRequest();

            request.MnemonicSentence = null;
            
            // Act & Assert
            TestInvalidRequestExceptionIsThrownOn(() => request.ToRestRequest(), exceptionExceptionMessage);
        }

        [TestMethod]
        public void ToRestRequest_MnemonicSentenceHasLessThan15Words_ThrowInvalidRequestException()
        {
            // Assemble
            const string exceptionExceptionMessage =
                "The mnemonic sentence must contain at least 15 words. Only 1 word(s) were provided.";

            var request = CreateNominalRequest();

            request.MnemonicSentence = 1.Times(() => "word");
            
            // Act & Assert
            TestInvalidRequestExceptionIsThrownOn(() => request.ToRestRequest(), exceptionExceptionMessage);
        }

        [TestMethod]
        public void ToRestRequest_MnemonicSentenceHasMoreThan24Words_ThrowInvalidRequestException()
        {
            // Assemble
            const string exceptionExceptionMessage =
                "The mnemonic sentence cannot contain more than 24 words. 25 word(s) were provided.";

            var request = CreateNominalRequest();

            request.MnemonicSentence = 25.Times(() => "word");

            // Act & Assert
            TestInvalidRequestExceptionIsThrownOn(() => request.ToRestRequest(), exceptionExceptionMessage);
        }

        [TestMethod]
        public void ToRestRequest_MnemonicSecondFactorIsNull_NoExceptionIsThrown()
        {
            // Assemble
            var request = CreateNominalRequest();

            request.MnemonicSecondFactor = null;

            // Act & Assert
            TestNoExceptionIsThrownOn(() => request.ToRestRequest());
        }

        [TestMethod]
        public void ToRestRequest_MnemonicSecondFactorHasLessThan9Words_ThrowInvalidRequestException()
        {
            // Assemble
            const string exceptionExceptionMessage =
                "The mnemonic second factor must contain at least 9 words. Only 1 word(s) were provided.";

            var request = CreateNominalRequest();

            request.MnemonicSecondFactor = 1.Times(() => "word");

            // Act & Assert
            TestInvalidRequestExceptionIsThrownOn(() => request.ToRestRequest(), exceptionExceptionMessage);
        }

        [TestMethod]
        public void ToRestRequest_MnemonicSecondFactorHasMoreThan12Words_ThrowInvalidRequestException()
        {
            // Assemble
            const string exceptionExceptionMessage =
                "The mnemonic second factor cannot contain more than 12 words. 13 word(s) were provided.";

            var request = CreateNominalRequest();

            request.MnemonicSecondFactor = 13.Times(() => "word");

            // Act & Assert
            TestInvalidRequestExceptionIsThrownOn(() => request.ToRestRequest(), exceptionExceptionMessage);
        }

        [TestMethod]
        public void ToRestRequest_PassphraseIsNull_ThrowInvalidRequestException()
        {
            // Assemble
            const string exceptionExceptionMessage = "A value for the \"Passphrase\" property is required.";

            var request = CreateNominalRequest();

            request.Passphrase = null;

            // Act & Assert
            TestInvalidRequestExceptionIsThrownOn(() => request.ToRestRequest(), exceptionExceptionMessage);
        }

        [TestMethod]
        public void ToRestRequest_PassphraseHasLessThan10Characters_ThrowInvalidRequestException()
        {
            // Assemble
            const string exceptionExceptionMessage = 
                "The passphrase cannot be less than 10 characters. 9 character(s) were provided.";

            var request = CreateNominalRequest();

            request.Passphrase = "123456789";

            // Act & Assert
            TestInvalidRequestExceptionIsThrownOn(() => request.ToRestRequest(), exceptionExceptionMessage);
        }

        [TestMethod]
        public void ToRestRequest_PassphraseHasMoreThan255Characters_ThrowInvalidRequestException()
        {
            // Assemble
            const string exceptionExceptionMessage = 
                "The passphrase cannot have more than 255 characters. 256 character(s) were provided.";

            var request = CreateNominalRequest();
            
            var tooLongPassphrase = string.Join(string.Empty, 256.Times(() => "a"));

            request.Passphrase = tooLongPassphrase;

            // Act & Assert
            TestInvalidRequestExceptionIsThrownOn(() => request.ToRestRequest(), exceptionExceptionMessage);
        }

        private static CreateOrRestoreWalletWithMnemonicSeedRequest CreateNominalRequest()
        {
            return new CreateOrRestoreWalletWithMnemonicSeedRequest
            {
                Name = NominalWalletName,
                MnemonicSentence = NominalMnemonicSentence,
                MnemonicSecondFactor = NominalSecondFactor,
                Passphrase = NominalPassphrase,
                AddressPoolGap = NominalAddressPoolGap
            };
        }
    }
}