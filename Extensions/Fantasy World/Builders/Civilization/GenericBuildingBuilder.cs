using System;
using PGE.Core.Builder;
using PGE.Core.Models;
using PGE.Fantasy_World.Models.Civilization;
using PGE.Fantasy_World.Models.Life;

namespace PGE.Fantasy_World.Builders.Civilization
{
    public class GenericBuildingBuilder : IBuilder<Building>
    {
        protected Humanoid _owner;
        protected string _buildingType = "Generic Building";
        protected string _name = "The Generic Building";

        public Building Build()
        {
            SetRelationshipDefaults();

            return new Building()
            {
                Name = _name,
                Owner = _owner,
                Type = _buildingType
            };
        }

        public void SetRelationshipDefaults()
        {
            if (_owner == null)
            {
                _owner = new Humanoid();
            }
        }

        public Building ProceduralBuild(Model @from, Type until = null)
        {
            throw new NotImplementedException();
        }

        public GenericBuildingBuilder WithOwner(Humanoid owner)
        {
            _owner = owner;
            return this;
        }

        public GenericBuildingBuilder WithType(string type)
        {
            _buildingType = type;
            return this;
        }

        public GenericBuildingBuilder WithName(string name)
        {
            _name = name;
            return this;
        }
    }
}
