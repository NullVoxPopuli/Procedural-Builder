using PGE.Core.Generated_Items;
using PGE.Fantasy_World.Lifeforms.Objects;

namespace PGE.Fantasy_World.Civilization.Buildings.Objects
{
    public class Building : IGeneratable
    {
        public string Name;
        public string Type;
        public Humanoid Owner;
    }
}
