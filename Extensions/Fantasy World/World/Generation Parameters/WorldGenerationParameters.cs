using PGE.Core.Generated_Items;

namespace PGE.Fantasy_World.World.Generation_Parameters
{
    public class WorldGenerationParameters : GenerationParameters
    {
        public override void ApplyParameters(AbstractGeneratableObject gen)
        {
            Generated = gen;

            ((Objects.World)Generated).GenerateContinents();
        }
    }
}
