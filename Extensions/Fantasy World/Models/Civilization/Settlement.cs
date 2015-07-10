using System.Collections.Generic;
using PGE.Core.Models;
using PGE.Fantasy_World.Builders.Civilization.Civilization.Civilization.Objects;
using PGE.Fantasy_World.Models.Life;

namespace PGE.Fantasy_World.Civilization.Macro.Objects
{
    public class Settlement : Model
    {
        public List<Humanoid> Citizens;
        public List<Building> Buildings;

        // Procedurally generate these
        public string Government;
    }
}
