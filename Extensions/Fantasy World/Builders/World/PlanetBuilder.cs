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

        // Generic, Non-Procedural Build
        public Planet Build()
        {
            SetRelationshipDefaults();

            var planet = new Planet()
            {
                Continents = _continents
            };

            return planet;
        }

        // Master Procedural-Build. Starts the chain of generation here
        public Planet Build(Type until)
        {
            var planet = Build();

            planet.ProceduralBuild(until);

            return planet;
        }

        // Linked Procedural Build. Continus in the chain of generation
        public Planet Build(GeneratedModel @from, Type until = null)
        {
            // Since this is the head of generation, use Master-variant Build instead
            return Build(until);
        }

        // Used for creating default object Relationships to prevent nulls
        public void SetRelationshipDefaults()
        {
            if (_continents == null)
            {
                _continents = new List<Landmass>();
            }
        }
    }
}
