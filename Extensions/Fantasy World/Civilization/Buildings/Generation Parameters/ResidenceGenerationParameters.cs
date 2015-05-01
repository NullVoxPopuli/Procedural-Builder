using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Civilization.Buildings.Objects;
using PGE.Fantasy_World.Lifeforms.Objects;

namespace PGE.Fantasy_World.Civilization.Buildings.Generation_Parameters
{
    public class ResidenceGenerationParameters : GenericBuildingGenerationParameters
    {
        private List<Humanoid> _inhabitants;

        public override void ApplyParameters(IGeneratable gen)
        {
            base.ApplyParameters(gen);

            ApplyInhabitants();
        }

        #region Handle Type

        protected override void GenerateType()
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
            ((Building)Generated).Type = Dice.RollOnTable(residenceTable);
        }

        #endregion
        #region Handle Inhabintants

        public void SetInhabitants(List<Humanoid> inhabitants)
        {
            _inhabitants = inhabitants;
        }

        private void ApplyInhabitants()
        {
            if (_inhabitants == null)
            {
                GenerateInhabitants();
            }

            ((Residence)Generated).Inhabitants = _inhabitants;
        }

        private void GenerateInhabitants()
        {
            _inhabitants = new List<Humanoid>();
        }

        #endregion
    }
}
