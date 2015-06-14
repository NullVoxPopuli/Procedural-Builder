using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Civilization.Buildings.Objects;

namespace PGE.Fantasy_World.Civilization.Buildings.Generation_Parameters
{
    public class WarehouseGenerationParameters : GenericBuildingGenerationParameters
    {
        private List<string> _inventory; 

        public override void ApplyParameters(AbstractGeneratableObject gen)
        {
            base.ApplyParameters(gen);

            ApplyInventory();
        }

        #region Handle Type

        protected override void GenerateType()
        {
            var warehouseTable = new List<string>
            {
                "Empty",
                "Empty",
                "Abandoned",
                "Abandoned",
                "Heavily guarded, expensive goods",
                "Heavily guarded, expensive goods",
                "Cheap goods",
                "Cheap goods",
                "Cheap goods",
                "Cheap goods",
                "Bulk Goods",
                "Bulk Goods",
                "Bulk Goods",
                "Bulk Goods",
                "Live Animals",
                "Weapons",
                "Armor",
                "Weapons and Armor",
                "Goods from distant land",
                "Goods from distant land",
                "Secret smuggler's den"
            };

            BuildingType = Dice.RollOnTable(warehouseTable);
        }

        #endregion
        #region Handle Inventory

        public void SetInventory(List<string> inventory)
        {
            _inventory = inventory;
        }

        private void ApplyInventory()
        {
            if (_inventory == null)
            {
                GenerateInventory();
            }

            ((Warehouse)Generated).Inventory = _inventory;
        }

        private void GenerateInventory()
        {
            _inventory = new List<string>();
        }

        #endregion
    }
}
