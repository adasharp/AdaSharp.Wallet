using System;
using System.Collections.Generic;
using AdaSharp.Tests.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests
{
    public abstract class TestBase
    {
        // TODO: Move to AssertExtensions
        protected void TestExpectedExceptionIsThrownOn(Action systemUnderTest, Exception expectedExceptionToBeThrown)
        {
            if (systemUnderTest == null)
            {
                throw new ArgumentNullException(nameof(systemUnderTest));
            }

            if (expectedExceptionToBeThrown == null)
            {
                throw new ArgumentNullException(nameof(expectedExceptionToBeThrown));
            }

            var exceptionWasNotThrown = false;

            try
            {
                // Act
                systemUnderTest.Invoke();
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

        protected List<T> EmptyListOf<T>()
        {
            return new List<T>();
        }
    }
}