using System.Collections.Generic;
using PGE.Core.Builder;
using PGE.Fantasy_World.Builders.Civilization.Civilization.Civilization.Objects;
using PGE.Fantasy_World.Civilization.Macro.Objects;
using PGE.Fantasy_World.Models.Life;

namespace PGE.Fantasy_World.Civilization.Macro.Builders
{
    public class SettlementBuilder : IBuilder<Settlement>
    {
        private List<Humanoid> _population;
        private List<Building> _buildings;
        private string _government = "";

        public Settlement Build()
        {
            return new Settlement()
            {
                Buildings = _buildings,
                Citizens = _population,
                Government = _government
            };
        }

        public void SetRelationshipDefaults()
        {
            if (_population == null)
            {
                _population = new List<Humanoid>();
            }
        }

        public SettlementBuilder WithGovernment(string govt)
        {
            _government = govt;
            return this;
        }

        public SettlementBuilder WithBuildings(List<Building> buildings)
        {
            _buildings = buildings;
            return this;
        }

        public SettlementBuilder WithPopulation(List<Humanoid> pop)
        {
            _population = pop;
            return this;
        }
    }
}
