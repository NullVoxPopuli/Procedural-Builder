using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Core.Statistics;

namespace Generator_Core_Tests.Generatable_Test_Items
{
    class TestGenerationParameters : GenerationParameters
    {
        public override void ApplyParameters(AbstractGeneratableObject gen)
        {
            Generated = gen;

            SetDescription();
        }

        private void SetDescription()
        {
            var descriptionTable = new List<string>()
            {
                "Description"
            };

            ((TestGenerated)Generated).Description = Dice.RollOnTable(descriptionTable);
        }
    }
}
