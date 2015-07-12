using System;
using System.Collections.Generic;
using PGE.Core.Models;
using PGE.Core.Statistics;

namespace PGE.Fantasy_World.Models.World
{
    public class Landmass : Model
    {
        public List<Region> Regions;

        // Input parameters should examine the effects of the Planet on the landmass

        public double ContinentSize;

        // Where 0.0 is located on the equator
        // Where 1.0 is located at a pole
        public double ProximityToEquator;

        // Maximum number of Regions
        public int MaximumNumberOfRegions = 6;

        // Does this landmass have many environments, or is it just a single expansive region?
        // 0.0 = No Diversity
        // 1.0 = As many as <MaximumNumberOfRegions> Separate Regions
        public double RegionDiversity;

        // Average Rainfall and Temperature for this continent; used to drive Biome Generation in Regions
        // -1.0 == No Rain or Extremely Cold
        // 0.0 is roughly equivalent to temperate climates
        // 1.0 == Heavy, frequent rainfall; Extremely hot
        public double AverageRainfall;
        public double AverageTemperature;

        public double AverageSoilNitrogenContent;
        public int AverageHoursOfAvailableSunlight;
        public double AverageSunlightConcentration;
    }
}
