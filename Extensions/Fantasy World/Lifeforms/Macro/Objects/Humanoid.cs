using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Fantasy_World.Lifeforms.Micro.Objects;

namespace PGE.Fantasy_World.Lifeforms.Objects
{
    // Chief drivers of history
    public class Humanoid : AbstractGeneratableObject
    {
        public string Name;
        public string Ideals;
        public string Alignment;
        public string Appearance;
        public string HighAbility;
        public string LowAbility;
        public string Talents;
        public string Mannerisms;
        public string InteractionTraits;
        public string Bonds;
        public string FlawOrSecret;

        // A list of different traits inherited from parents. Heredity is determined
        // based on that trait's HereditaryNature (Dominant, Recessive, X-Only, etc)
        public List<Trait> Traits;
    }
}
