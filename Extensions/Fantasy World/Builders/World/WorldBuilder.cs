using PGE.Core.Builder;
using PGE.Core.Models;

namespace PGE.Fantasy_World.Builders.Civilization.Civilization.World
{
    public class WorldBuilder : IBuilder<World>
    {
        public World Build()
        {
            return new World();
        }

        public void SetRelationshipDefaults()
        {
            throw new System.NotImplementedException();
        }
    }
}
