using System.Collections.Generic;
using System.Linq;
using AdaSharp.Model;
using AdaSharp.Model.Shelley.Wallets;

namespace AdaSharp.Tests.Model
{
    public abstract class CardanoNodeResponseTestBase : TestBase
    {
        protected WalletPassphrase BuildWalletPassphrase(string lastUpdateAt)
        {
            return new WalletPassphrase
            {
                LastUpdatedAt = lastUpdateAt
            };
        }

        private UnitOfMeasure BuildUnitOfMeasure(int quantity, string unit)
        {
            return new UnitOfMeasure
            {
                Quantity = quantity,
                Unit = unit
            };
        }

        protected SyncState BuildSyncState(SyncStatus status, UnitOfMeasure progress)
        {
            return new SyncState
            {
                Status = status,
                Progress = progress
            };
        }

        protected TipWithHeight BuildTipWithHeight(
            int absoluteSlotNumber, int slotNumber, int epochNumber, string time,
            UnitOfMeasure height)
        {
            return new TipWithHeight
            {
                AbsoluteSlotNumber = absoluteSlotNumber,
                SlotNumber = slotNumber,
                EpochNumber = epochNumber,
                Time = time,
                Height = height
            };
        }

        protected Tip BuildTip(int absoluteSlotNumber, int slotNumber, int epochNumber, string time)
        {
            return new Tip
            {
                AbsoluteSlotNumber = absoluteSlotNumber,
                SlotNumber = slotNumber,
                EpochNumber = epochNumber,
                Time = time
            };
        }

        protected AssetBalance BuildAssetBalance(IEnumerable<UnitOfMeasure> available, IEnumerable<UnitOfMeasure> total)
        {
            return new AssetBalance
            {
                Available = available?.ToList(),
                Total = total?.ToList()
            };
        }

        protected UnitOfMeasure QuantityInLovelace(int quantity)
        {
            return BuildUnitOfMeasure(quantity, "lovelace");
        }

        protected UnitOfMeasure QuantityInBlocks(int quantity)
        {
            return BuildUnitOfMeasure(quantity, "block");
        }

        protected UnitOfMeasure QuantityInMicroseconds(int quantity)
        {
            return BuildUnitOfMeasure(quantity, "microsecond");
        }

        protected UnitOfMeasure QuantityInSeconds(int quantity)
        {
            return BuildUnitOfMeasure(quantity, "second");
        }

        protected UnitOfMeasure QuantityInSlots(int quantity)
        {
            return BuildUnitOfMeasure(quantity, "slot");
        }

        protected UnitOfMeasure QuantityInPercent(int quantity)
        {
            return BuildUnitOfMeasure(quantity, "percent");
        }
    }
}