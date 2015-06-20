﻿using System;
using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Core.Generator;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Civilization.Macro.Objects;
using PGE.Fantasy_World.World.Generation_Parameters;

namespace PGE.Fantasy_World.World.Objects
{
    public class Landmass : AbstractGeneratableObject
    {
        public List<Region> Regions;

        // Input parameters should examine the effects of the Planet on the landmass

        // Maximum number of Regions
        public int MaximumNumberOfRegions = 6;

        // Does this landmass have many environments, or is it just a single expansive region?
        // 0.0 = No Diversity
        // 1.0 = As many as <MaximumNumberOfRegions> Separate Regions
        public double RegionDiversity;

        public void GenerateRegions()
        {
            var numberOfRegions = Dice.Roll((int)(MaximumNumberOfRegions * RegionDiversity));

            // Prepare the basic Build Parameters for the Landmasses using our statistics
            var generator = new Generator<Region>();
            var regionParams  = new RegionGenerationParameters();
            generator.Add(regionParams);

            for (var regionIndex = 0; regionIndex < numberOfRegions; ++regionIndex)
            {
                Regions.Add(generator.Build());
            }
        }
    }
}
