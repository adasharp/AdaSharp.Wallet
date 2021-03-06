using System;
using AdaSharp.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests
{
    public abstract class TestBase
    {
        protected void TestExpectedExceptionIsThrownOn(Action action, Exception expectedExceptionToBeThrown)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (expectedExceptionToBeThrown == null)
            {
                throw new ArgumentNullException(nameof(expectedExceptionToBeThrown));
            }

            var exceptionWasNotThrown = false;

            try
            {
                // Act
                action.Invoke();
                exceptionWasNotThrown = true;
            }
            catch (Exception actualEx)
            {
                Assert.That.AreEqual(expectedExceptionToBeThrown, actualEx);
            }

            if (exceptionWasNotThrown == false)
            {
                return;
            }

            var expectedExceptionType = expectedExceptionToBeThrown.GetType();

            Assert.Fail($"The expected exception type \"{expectedExceptionType.Name}\" was not thrown.");
        }

        protected void TestNoExceptionIsThrownOn(Action action)
        {
            try
            {
                // Act
                action.Invoke();
            }
            catch (Exception ex)
            {
                var exType = ex.GetType();

                Assert.Fail($"An instance of {exType.Name} was thrown.");
            }
        }
    }
}