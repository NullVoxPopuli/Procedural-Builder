using System.Collections.Generic;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Models.Civilization;

namespace PGE.Fantasy_World.Builders.Civilization
{
    public class ShopBuilder : GenericBuildingBuilder
    {
        private List<string> _inventory;
        private string _wealth;

        public Shop Build()
        {
            return new Shop()
            {
                Name = _name,
                Owner = _owner,
                Type = _buildingType,
                Inventory = _inventory,
                Wealth = _wealth
            };
        }

        public void SetRelationshipDefaults()
        {
            base.SetRelationshipDefaults();

            if (string.IsNullOrEmpty(_buildingType))
            {
                GenerateType();
            }
            if (_inventory == null)
            {
                _inventory = new List<string>();
            }
        }

        public ShopBuilder WithInventory(List<string> inventory)
        {
            _inventory = inventory;
            return this;
        }

        public ShopBuilder WithWealth(string wealth)
        {
            _wealth = wealth;
            return this;
        }

        protected void GenerateType()
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

            _buildingType = Dice.RollOnTable(shopTypeTable);
        }
    }
}
