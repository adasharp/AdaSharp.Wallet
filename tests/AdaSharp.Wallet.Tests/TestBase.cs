using System;
using AdaSharp.Model;
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
                AssertAreEqual(expectedExceptionToBeThrown, actualEx);
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

        protected static void AssertAreEqual(Exception expected, Exception actual)
        {
            if (expected != null)
            {
                Assert.IsNotNull(actual);
            }
            else
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsInstanceOfType(actual, expected.GetType());
            Assert.AreEqual(expected.Message, actual.Message);

            if (IsArgumentExceptionType(actual))
            {
                var expectedArgEx = (ArgumentException)expected;
                var actualArgEx = (ArgumentException)actual;

                AssertArgumentException(expectedArgEx, actualArgEx);
            }
        }

        private static void AssertArgumentException(ArgumentException expected, ArgumentException actual)
        {
            Assert.AreEqual(expected.ParamName, actual.ParamName);
        }

        private static bool IsArgumentExceptionType(Exception exception)
        {
            var isArgumentExceptionType = exception.GetType() == typeof(ArgumentException);
            var inheritsArgumentException = exception.GetType().IsSubclassOf(typeof(ArgumentException));

            return isArgumentExceptionType || inheritsArgumentException;
        }

        // TODO: Refactor old tests.
        protected static void AssertAreEqual(UnitOfMeasure expected, UnitOfMeasure actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }
            
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Quantity, actual.Quantity);
            Assert.AreEqual(expected.Unit, actual.Unit);
        }

        protected static void AssertAreEqual(Epoch expected, Epoch actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Number, actual.Number);
            Assert.AreEqual(expected.StartTime, actual.StartTime);
        }
    }
}