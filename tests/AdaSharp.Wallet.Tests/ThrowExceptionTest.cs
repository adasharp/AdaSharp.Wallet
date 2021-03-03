using System;
using System.Runtime.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests
{
    /// <summary>
    /// Used to verify that the correct exception is thrown when the system-under-test is invoked.
    /// </summary>
    /// <remarks>
    /// This class was created to help keep the code in the unit test project somewhat cleaner. Originally, the
    /// code in the test cases were starting to get a bit messy, a little bit harder to read. I opted to explore
    /// other options to help accomplish the goal of keeping the code readable.
    /// </remarks>
    // TODO: Revisit if this is still a good idea. In my head it was a good idea, but as it was put into use,
    // the code got larger.
    public class ThrowExceptionTest
    {
        private Exception _expectedException;

        public ThrowExceptionTest(Exception expectedExceptionToBeThrown)
        {
            ExpectedExceptionToBeThrown = expectedExceptionToBeThrown;
        }

        public Exception ExpectedExceptionToBeThrown
        {
            get => _expectedException;
            set
            {
                if (value == null)
                {
                    var message = $"The \"{nameof(ExpectedExceptionToBeThrown)}\" property cannot be null.";

                    throw new ArgumentNullException(nameof(value), message);
                }

                _expectedException = value;
            }
        }

        public void AssertExceptionIsThrownOn(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
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
                AssertAreEqual(ExpectedExceptionToBeThrown, actualEx);
            }

            if (exceptionWasNotThrown == false)
            {
                return;
            }

            var expectedExceptionType = ExpectedExceptionToBeThrown.GetType();

            Assert.Fail($"The expected exception type \"{expectedExceptionType.Name}\" was not thrown.");
        }

        protected virtual void AssertAreEqual(Exception expected, Exception actual)
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
    }
}