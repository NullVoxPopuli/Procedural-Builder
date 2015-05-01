using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Fantasy_World.Civilization.Macro.Objects;

namespace PGE.Fantasy_World.World.Objects
{
    public class Landmass : IGeneratable
    {
        public List<Biome> Environments;
        public List<Settlement> Settlements;
    }
}
