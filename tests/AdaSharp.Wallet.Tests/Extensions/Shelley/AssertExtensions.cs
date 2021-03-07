using System.Collections.Generic;
using AdaSharp.Model.Shelley.Wallets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdaSharp.Tests.Extensions.Shelley
{
    internal static class AssertExtensions
    {
        public static void AreEqual(this Assert assert, Wallet expected, Wallet actual)
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

        public static void AreEqual(this Assert assert, WalletBalance expected, WalletBalance actual)
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

        public static void AreEqual(
            this Assert assert, 
            WalletDelegationSettings expected, WalletDelegationSettings actual)
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

        public static void AreEqual(this Assert assert, Delegation expected, Delegation actual)
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

        public static void AreEqual(this Assert assert, List<DelegationChange> expected, List<DelegationChange> actual)
        {
            Assert.That.AreEqual(expected, actual, Assert.That.AreEqual);
        }

        public static void AreEqual(this Assert assert, DelegationChange expected, DelegationChange actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.That.AreEqual(expected.ChangesAt, actual.ChangesAt);

            var expectedCastToBaseType = (Delegation) expected;
            var actualCastToBaseType = (Delegation) actual;

            Assert.That.AreEqual(expectedCastToBaseType, actualCastToBaseType);
        }

        public static void AreEqual(this Assert assert, AssetBalance expected, AssetBalance actual)
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

        public static void AreEqual(this Assert assert, WalletPassphrase expected, WalletPassphrase actual)
        {
            if (expected == null)
            {
                Assert.IsNull(actual);
                return;
            }

            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.LastUpdatedAt, actual.LastUpdatedAt);
        }
    }
}