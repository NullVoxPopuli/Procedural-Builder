using PGE.Core.Models;
using PGE.Fantasy_World.Models.Life;

namespace PGE.Fantasy_World.Models.Civilization
{
    public class Building : Model
    {
        public string Name;
        public string Type;
        public Humanoid Owner;
    }
}
