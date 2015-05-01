using PGE.Core.Generated_Items;
using PGE.Core.Generator;
using PGE.Fantasy_World.Civilization.Buildings.Objects;
using PGE.Fantasy_World.Lifeforms.Generation_Parameters;
using PGE.Fantasy_World.Lifeforms.Objects;

namespace PGE.Fantasy_World.Civilization.Buildings.Generation_Parameters
{
    public class GenericBuildingGenerationParameters : GenerationParameters
    {
        private Humanoid _owner;
        protected string BuildingType, Name;

        public override void ApplyParameters(IGeneratable gen)
        {
            Generated = gen;

            ApplyOwner();
            ApplyType();
            ApplyName();
        }

        #region Handle Owner

        public void SetOwner(Humanoid npc)
        {
            _owner = npc;
        }

        private void ApplyOwner()
        {
            if (_owner == null)
            {
                GenerateOwner();
            }

            ((Building)Generated).Owner = _owner;
        }

        private void GenerateOwner()
        {
            var gen = new Generator<Humanoid>();
            var generationParams = new HumanoidGenerationParameters();
            gen.Add(generationParams);

            _owner = gen.Build();
        }

        #endregion
        #region Handle Building Type

        public void SetType(string type)
        {
            BuildingType = type;
        }

        private void ApplyType()
        {
            if (_owner == null)
            {
                GenerateType();
            }

            ((Building)Generated).Type = BuildingType;
        }

        // Override this
        protected virtual void GenerateType()
        {
            BuildingType = "Generic type";
        }

        #endregion
        #region Handle Building Name

        public void SetName(string name)
        {
            Name = name;
        }

        private void ApplyName()
        {
            if (Name == null)
            {
                GenerateName();
            }

            ((Building)Generated).Name = Name;
        }

        // Override this
        protected virtual void GenerateName()
        {
            Name = "Generic Name";
        }

        #endregion
    }
}
