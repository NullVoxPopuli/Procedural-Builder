using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGE.Core.Generated_Items;
using PGE.Fantasy_World.Civilization.Macro.Objects;
using PGE.Fantasy_World.World.Objects;

namespace PGE.Fantasy_World.World.Generation_Parameters
{
    public class RegionGenerationParameters : GenerationParameters
    {
        public override void ApplyParameters(AbstractGeneratableObject gen)
        {
            Generated = gen;

            ((Region)Generated).GenerateSettlements();
        }
    }
}
