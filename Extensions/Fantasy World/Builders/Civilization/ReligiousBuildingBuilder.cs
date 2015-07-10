using System;
using System.Collections.Generic;
using PGE.Core.Builder;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Builders.Civilization.Civilization.Civilization.Objects;

namespace PGE.Fantasy_World.Builders.Civilization
{
    public class ReligiousBuildingBuilder : GenericBuildingBuilder
    {
        protected string _patron = "Unnamed Deity";

        public ReligiousBuilding Build()
        {
            return new ReligiousBuilding()
            {
                Name = _name,
                Owner = _owner,
                Patron = _patron,
                Type = _buildingType
            };
        }

        public ReligiousBuildingBuilder WithPatron(string patron)
        {
            _patron = patron;
            return this;
        }


        public void SetRelationshipDefaults()
        {
            base.SetRelationshipDefaults();

            if (String.IsNullOrEmpty(_buildingType))
            {
                GenerateType();
            }
        }

        private void GenerateType()
        {
            var religiousTable = new List<string>
            {
                "Temple to a good deity",
                "Temple to a good deity",
                "Temple to a good deity",
                "Temple to a good deity",
                "Temple to a good deity",
                "Temple to a neutral deity",
                "Temple to a neutral deity",
                "Temple to a neutral deity",
                "Temple to a neutral deity",
                "Temple to a neutral deity",
                "Temple to a false deity",
                "Temple to a false deity",
                "Home of ascetics",
                "Abandoned shrine",
                "Abandoned shrine",
                "Library dedicated to religious study",
                "Library dedicated to religious study",
                "Hidden shrine to fiend",
                "Hidden shrine to evil deity",
                "Hidden shrine to evil deity"
            };
        
            _buildingType = Dice.RollOnTable(religiousTable);
        }
    }
}
