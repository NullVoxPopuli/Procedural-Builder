using PGE.Core.Generated_Items;

namespace PGE.Fantasy_World.World.Objects
{
    public class Biome : AbstractGeneratableObject
    {
        // Description of an environment, and thus, should contain information about weather
        
        // Rate of precipitation
        // Where -1.0 is the absence of rain and 1.0 is a constant monsoon
        public double Preciptitation;

        // Wind amount
        public double WindAmount;

        // Heat Statistics
        public double TemperatureStandardDeviation;
        public double TemperatureAverage;

        // Where -1.0 is completely unstable
        // 0.0 is standard seasons
        // 1.0 is a single season
        public double StabilityOfClimate;
    }
}
