using PGE.Core.Generated_Items;
using PGE.Fantasy_World.World.Objects;

namespace PGE.Fantasy_World.World.Generation_Parameters
{
    public class LandmassGenerationParameters : GenerationParameters
    {
        public override void ApplyParameters(AbstractGeneratableObject gen)
        {
            Generated = gen;

            ((Landmass)Generated).GenerateRegions();
        }
    }
}
