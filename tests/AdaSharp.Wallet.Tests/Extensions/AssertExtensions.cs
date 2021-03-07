using System;
using System.Collections.Generic;
using AdaSharp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests.Extensions
{
    internal static class AssertExtensions
    {
        public static void AreEqual(this Assert assert, SyncState expected, SyncState actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Status, actual.Status);
            Assert.That.AreEqual(expected.Progress, actual.Progress);
        }

        public static void AreEqual(this Assert assert, TipWithHeight expected, TipWithHeight actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.That.AreEqual(expected.Height, actual.Height);

            var expectedCastToBaseType = (Tip) expected;
            var actualCastToBaseType = (Tip) actual;

            Assert.That.AreEqual(expectedCastToBaseType, actualCastToBaseType);
        }

        public static void AreEqual(this Assert assert, Tip expected, Tip actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.AbsoluteSlotNumber, actual.AbsoluteSlotNumber);
            Assert.AreEqual(expected.SlotNumber, actual.SlotNumber);
            Assert.AreEqual(expected.EpochNumber, actual.EpochNumber);
            Assert.AreEqual(expected.Time, actual.Time);
        }

        public static void AreEqual(this Assert assert, List<UnitOfMeasure> expected, List<UnitOfMeasure> actual)
        {
            Assert.That.AreEqual(expected, actual, Assert.That.AreEqual);
        }

        public static void AreEqual<T>(
            this Assert assert, 
            List<T> expected, List<T> actual,
            AssertAreEqualDelegate<T> assertAreEqualDelegate) 
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count);

            for (var index = 0; index < expected.Count; index++)
            {
                var expectedItem = expected[index];
                var actualItem = actual[index];

                // TODO: Ugh - this is not good. One will not know which 
                // item in the array failed assertion.
                assertAreEqualDelegate.Invoke(expectedItem, actualItem);
            }
        }

        public static void AreEqual(this Assert assert, UnitOfMeasure expected, UnitOfMeasure actual)
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

        public static void AreEqual(this Assert assert, Epoch expected, Epoch actual)
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

        public static void AreEqual(this Assert assert, Exception expected, Exception actual)
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