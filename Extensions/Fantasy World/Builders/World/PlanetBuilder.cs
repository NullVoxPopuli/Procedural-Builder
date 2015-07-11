using System;
using PGE.Core.Builder;
using PGE.Core.Models;
using PGE.Fantasy_World.Models.World;

namespace PGE.Fantasy_World.Builders.World
{
    public class PlanetBuilder : IBuilder<Planet>
    {
        public Planet Build()
        {
            return new Planet();
        }

        public void SetRelationshipDefaults()
        {
            throw new System.NotImplementedException();
        }

        public Planet ProceduralBuild(Model @from, Type until = null)
        {
            // Planet is top-most
            throw new System.NotImplementedException();
        }
    }
}
