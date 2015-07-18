using System;
using System.Collections.Generic;
using PGE.Core.Builder;
using PGE.Core.Models;
using PGE.Fantasy_World.Models.Civilization;
using PGE.Fantasy_World.Models.Life;

namespace PGE.Fantasy_World.Builders.Civilization
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

        public Settlement ProceduralBuild(GeneratedModel @from, Type until = null)
        {
            throw new NotImplementedException();
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
