using System;
using AdaSharp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests.Model
{
    public abstract class CardanoNodeRequestTestBase : TestBase
    {
        // TODO: Apply this to all test classes.
        protected void AssertRestResourceUriIs(string expectedValue, CardanoNodeRequest request)
        {
            // Act
            var result = request.ToRestRequest();

            // Assert
            Assert.AreEqual(expectedValue, result.Resource);
        }

        // TODO: Apply this to all test classes.
        protected void TestInvalidRequestExceptionIsThrownOn(Action systemUnderTest, string expectedExceptionMessage)
        {
            var expectedException = new InvalidRequestException(expectedExceptionMessage);

            TestExpectedExceptionIsThrownOn(systemUnderTest, expectedException);
        }
    }
}