using System;
using System.Collections.Generic;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Models.Civilization;
using PGE.Fantasy_World.Models.Life;

namespace PGE.Fantasy_World.Builders.Civilization
{
    public class ResidenceBuilder : GenericBuildingBuilder
    {
        private List<Humanoid> _inhabitants;

        public Residence Build()
        {
            return new Residence()
            {
                Name = _name,
                Owner = _owner,
                Type = _buildingType,
                Inhabitants = _inhabitants
            };
        }

        public void SetRelationshipDefaults()
        {
            base.SetRelationshipDefaults();

            if (String.IsNullOrEmpty(_buildingType))
            {
                GenerateType();
            }
            if (_inhabitants == null)
            {
                _inhabitants = new List<Humanoid>();
            }
        }

        public ResidenceBuilder WithInhabitants(List<Humanoid> inhabitants)
        {
            _inhabitants = inhabitants;
            return this;
        }

        protected void GenerateType()
        {
            var residenceTable = new List<string>
            {
                "Abandoned squat",
                "Abandoned squat",
                "Middle-class home",
                "Middle-class home",
                "Middle-class home",
                "Middle-class home",
                "Middle-class home",
                "Middle-class home",
                "Upper-class home",
                "Upper-class home",
                "Crowded tenement",
                "Crowded tenement",
                "Crowded tenement",
                "Crowded tenement",
                "Crowded tenement",
                "Orphanage",
                "Orphanage",
                "Hidden slavers' den",
                "Front for secret cult",
                "Lavish, guarded mansion"
            };
            _buildingType = Dice.RollOnTable(residenceTable);
        }
    }
}
