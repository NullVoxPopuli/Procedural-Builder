using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Fantasy_World.Civilization.Buildings.Objects;
using PGE.Fantasy_World.Lifeforms.Objects;
using PGE.Fantasy_World.World.Objects;

namespace PGE.Fantasy_World.Civilization.Macro.Objects
{
    public class Settlement : AbstractGeneratableObject
    {
        public List<Humanoid> Citizens;
        public List<Building> Buildings;

        // Procedurally generate these
        public Biome Environment;
        public string Government;
    }
}
