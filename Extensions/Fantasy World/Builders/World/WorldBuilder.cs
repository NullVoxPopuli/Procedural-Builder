using PGE.Core.Builder;
using PGE.Fantasy_World.Models.World;

namespace PGE.Fantasy_World.Builders.World
{
    public class WorldBuilder : IBuilder<Planet>
    {
        public Planet Build()
        {
            return new Planet();
        }

        public void SetRelationshipDefaults()
        {
            throw new System.NotImplementedException();
        }
    }
}
