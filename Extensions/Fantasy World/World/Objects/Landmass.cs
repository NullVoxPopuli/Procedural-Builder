using System;
using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Fantasy_World.Civilization.Macro.Objects;

namespace PGE.Fantasy_World.World.Objects
{
    public class Landmass : AbstractGeneratableObject
    {
        public List<Biome> Environments;
        public List<Settlement> Settlements;

        // Input parameters should examine the effects of the Planet on the landmass

        // What is the moisture level?
        // -1.0 being arid desert
        // 0.0 being something like the midwest
        // 1.0 being rainforest levels of humidity
        public double RelativeMoistureLevel;

        // Parameters that should be handled by Procedural Generation
        private double _hospitabilityToFauna;
    }
}
