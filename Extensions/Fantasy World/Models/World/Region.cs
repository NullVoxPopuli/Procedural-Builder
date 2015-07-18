using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGE.Core.Models;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Models.Civilization;

namespace PGE.Fantasy_World.Models.World
{
    public class Region : GeneratedModel
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

        public void ProceduralBuild(Model from, Type until = null)
        {
            // Procedurally generate here
        }
    }
}
