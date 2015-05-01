using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Fantasy_World.Lifeforms.Micro.Objects;

namespace PGE.Fantasy_World.Lifeforms.Objects
{
    // Chief drivers of history
    public class Humanoid : IGeneratable
    {
        public string Name,
            Ideals,
            Alignment,
            Appearance,
            HighAbility,
            LowAbility,
            Talents,
            Mannerisms,
            InteractionTraits,
            Bonds,
            FlawOrSecret;

        // A list of different traits inherited from parents. Heredity is determined
        // based on that trait's HereditaryNature (Dominant, Recessive, X-Only, etc)
        public List<Trait> Traits;
    }
}
