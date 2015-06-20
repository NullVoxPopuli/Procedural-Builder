using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGE.Core.Generated_Items;
using PGE.Core.Generator;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Civilization.Macro.Objects;
using PGE.Fantasy_World.World.Generation_Parameters;

namespace PGE.Fantasy_World.World.Objects
{
    public class Region : AbstractGeneratableObject
    {
        public Biome Environment;
        public List<Settlement> Settlements;

        public void GenerateSettlements()
        {
            var biomeGenerator = new Generator<Biome>();
            var biomeParams = new BiomeGenerationParameters();
            biomeGenerator.Add(biomeParams);
            Environment = biomeGenerator.Build();

            // Prepare the basic Build Parameters for the Settlements using our statistics
            var settlementGenerator = new Generator<Settlement>();
            var settlementParams = new RegionGenerationParameters();
            settlementGenerator.Add(settlementParams);

            var numberOfSettlements = CalculateNumberOfSettlements();

            for (var regionIndex = 0; regionIndex < numberOfSettlements; ++regionIndex)
            {
                Settlements.Add(settlementGenerator.Build());
            }
        }

        private int CalculateNumberOfSettlements()
        {
            // Need to infer based on the Environment's hospitability and the size of the Region

            return Dice.Roll(4);
        }
    }
}
