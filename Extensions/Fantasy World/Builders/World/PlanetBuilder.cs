using System;
using System.Collections.Generic;
using PGE.Core.Builder;
using PGE.Core.Models;
using PGE.Fantasy_World.Models.World;

namespace PGE.Fantasy_World.Builders.World
{
    public class PlanetBuilder : IBuilder<Planet>
    {
        private List<Landmass> _continents;

        public Planet Build()
        {
            var planet = new Planet()
            {
                Continents = _continents
            };

            return planet;
        }

        // Can't build this!
        public Planet Build(GeneratedModel @from, Type until = null)
        {
            var planet = Build();

            planet.ProceduralBuild(until);
            
            return planet;
        }

        public void SetRelationshipDefaults()
        {
            if (_continents == null)
            {
                _continents = new List<Landmass>();
            }
        }
    }
}
