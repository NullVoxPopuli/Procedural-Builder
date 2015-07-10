using PGE.Core.Generated_Items;

namespace PGE.Fantasy_World.Civilization.Macro.Builders
{
    public class SettlementBuilder : Builder
    {
        private int _population = -1;

        public override void ApplyParameters(AbstractGeneratableObject gen)
        {
            Generated = gen;
            ApplyPopulation();
        }

        #region Environment

        #region Handle Environment

        #endregion
        #region Handle Environmental Effects

        #endregion

        #endregion

        #region Handle Population

        public void SetPopulation(int population)
        {
            _population = population;
        }

        private void ApplyPopulation()
        {
            if (_population == -1)
            {
                GeneratePopulation();
            }
        }

        private void GeneratePopulation()
        {
            _population = 1;
        }

        #endregion
    }
}
