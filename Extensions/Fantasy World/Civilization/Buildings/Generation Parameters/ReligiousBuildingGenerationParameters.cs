using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Civilization.Buildings.Objects;

namespace PGE.Fantasy_World.Civilization.Buildings.Generation_Parameters
{
    public class ReligiousBuildingGenerationParameters : GenericBuildingGenerationParameters
    {
        private string _patron;

        public override void ApplyParameters(IGeneratable gen)
        {
            base.ApplyParameters(gen);

            ApplyPatron();
        }

        #region Handle Type

        protected override void GenerateType()
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

            BuildingType = Dice.RollOnTable(religiousTable);
        }

        #endregion
        #region Handle Patron

        public void SetPatron(string patron)
        {
            _patron = patron;
        }

        private void ApplyPatron()
        {
            if (_patron == null)
            {
                GeneratePatron();
            }

            ((ReligiousBuilding) Generated).Patron = _patron;
        }

        private void GeneratePatron()
        {
            _patron = "unknown";
        }

        #endregion
    }
}
