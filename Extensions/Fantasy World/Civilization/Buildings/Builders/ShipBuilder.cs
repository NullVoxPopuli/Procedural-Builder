using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Civilization.Buildings.Objects;

namespace PGE.Fantasy_World.Civilization.Buildings.Generation_Parameters
{
    public class ShopBuilder : GenericBuildingBuilder
    {
        private List<string> _inventory; 

        public override void ApplyParameters(AbstractGeneratableObject gen)
        {
            base.ApplyParameters(gen);

            // Inventory should be its own object and be generated with several parameters
            //   1. Stocked Percentage
            //   2. Rarity
            ApplyInventory();
        }

        #region Handle Type

        protected override void GenerateType()
        {
            var shopTypeTable = new List<string>
            {
                "Pawnshop",
                "Herbs and Incense",
                "Fruits/Vegetables",
                "Dried Meats",
                "Pottery",
                "Undertaker",
                "Books",
                "Moneylender",
                "Smithy",
                "Used weapons and armor",
                "Chandler",
                "Carpenter",
                "Weaver",
                "Jeweler",
                "Baker",
                "Cartographer",
                "Tailor",
                "Ropemaker",
                "Mason",
                "Scribe"
            };

            BuildingType = Dice.RollOnTable(shopTypeTable);
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

            ((Shop)Generated).Inventory = _inventory;
        }

        private void GenerateInventory()
        {
            _inventory = new List<string>();
        }

        #endregion
    }
}
