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
        public List<Settlement> Settlements;

        // Wind amount
        public double WindAmount;

        // Fauna Characteristics
        public double AverageRainfall;
        public double AverageTemperature;
        public double SoilNitrogenContent;
        public int HoursOfAvailableSunlight;
        public double SunlightConcentration;

        // Where -1.0 is completely unstable
        // 0.0 is standard seasons
        // 1.0 is a single season
        public double StabilityOfClimate;

        public void GenerateSettlements()
        {
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
