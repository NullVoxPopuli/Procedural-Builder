using System.Collections.Generic;
using PGE.Core.Models;
using PGE.Fantasy_World.Models.Life;

namespace PGE.Fantasy_World.Models.Civilization
{
    public class Settlement : GeneratedModel
    {
        public List<Humanoid> Citizens;
        public List<Building> Buildings;

        // Procedurally generate these
        public string Government;
    }
}
