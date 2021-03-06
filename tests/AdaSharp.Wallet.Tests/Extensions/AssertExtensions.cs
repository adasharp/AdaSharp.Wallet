using System;
using System.Collections.Generic;
using AdaSharp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests.Extensions
{
    internal static class AssertExtensions
    {
        private delegate void ItemsAreEqualDelegate<in T>(T expected, T actual);

        public static void AreEqual(this Assert assert, 
            AdaSharp.Model.Shelley.Wallets.Wallet expected,
            AdaSharp.Model.Shelley.Wallets.Wallet actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.AddressPoolGap, actual.AddressPoolGap);
            Assert.That.AreEqual(expected.Balance, actual.Balance);
            Assert.That.AreEqual(expected.Delegation, actual.Delegation);
            Assert.That.AreEqual(expected.Assets, actual.Assets);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.That.AreEqual(expected.Passphrase, actual.Passphrase);
            Assert.That.AreEqual(expected.State, actual.State);
            Assert.That.AreEqual(expected.Tip, actual.Tip);
        }

        public static void AreEqual(this Assert assert,
            AdaSharp.Model.Shelley.Wallets.WalletBalance expected,
            AdaSharp.Model.Shelley.Wallets.WalletBalance actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.That.AreEqual(expected.Available, actual.Available);
            Assert.That.AreEqual(expected.Reward, actual.Reward);
            Assert.That.AreEqual(expected.Total, actual.Total);
        }

        public static void AreEqual(this Assert assert,
            AdaSharp.Model.Shelley.Wallets.WalletDelegationSettings expected,
            AdaSharp.Model.Shelley.Wallets.WalletDelegationSettings actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.That.AreEqual(expected.Active, actual.Active);
            Assert.That.AreEqual(expected.Next, actual.Next);
        }

        public static void AreEqual(this Assert assert,
            AdaSharp.Model.Shelley.Wallets.Delegation expected,
            AdaSharp.Model.Shelley.Wallets.Delegation actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Target, actual.Target);
            Assert.AreEqual(expected.Status, actual.Status);
        }

        public static void AreEqual(this Assert assert,
            List<AdaSharp.Model.Shelley.Wallets.DelegationChange> expected,
            List<AdaSharp.Model.Shelley.Wallets.DelegationChange> actual)
        {
            AssertItemsInListAreEqual(expected, actual, Assert.That.AreEqual);
        }

        public static void AreEqual(this Assert assert,
            AdaSharp.Model.Shelley.Wallets.DelegationChange expected,
            AdaSharp.Model.Shelley.Wallets.DelegationChange actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.That.AreEqual(expected.ChangesAt, actual.ChangesAt);
            Assert.AreEqual(expected.Target, actual.Target);
            Assert.AreEqual(expected.Status, actual.Status);
        }

        public static void AreEqual(this Assert assert,
            AdaSharp.Model.Shelley.Wallets.AssetBalance expected,
            AdaSharp.Model.Shelley.Wallets.AssetBalance actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.That.AreEqual(expected.Available, actual.Available);
            Assert.That.AreEqual(expected.Total, actual.Total);
        }

        public static void AreEqual(this Assert assert,
            AdaSharp.Model.Shelley.Wallets.WalletPassphrase expected,
            AdaSharp.Model.Shelley.Wallets.WalletPassphrase actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.LastUpdatedAt, actual.LastUpdatedAt);
        }

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
            Assert.AreEqual(expected.AbsoluteSlotNumber, actual.AbsoluteSlotNumber);
            Assert.AreEqual(expected.SlotNumber, actual.SlotNumber);
            Assert.AreEqual(expected.EpochNumber, actual.EpochNumber);
            Assert.AreEqual(expected.Time, actual.Time);
            Assert.That.AreEqual(expected.Height, actual.Height);
        }

        public static void AreEqual(this Assert assert, List<UnitOfMeasure> expected, List<UnitOfMeasure> actual)
        {
            AssertItemsInListAreEqual(expected, actual, Assert.That.AreEqual);
        }

        private static void AssertItemsInListAreEqual<T>(
            List<T> expected, List<T> actual,
            ItemsAreEqualDelegate<T> itemsAreEqualDelegate) where T : class
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
                itemsAreEqualDelegate.Invoke(expectedItem, actualItem);
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