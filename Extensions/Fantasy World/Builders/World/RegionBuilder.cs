using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGE.Core.Generated_Items;
using PGE.Fantasy_World.Civilization.Macro.Objects;
using PGE.Fantasy_World.Models.World;

namespace PGE.Fantasy_World.World.Builders
{
    public class RegionBuilder : Builder
    {
        public override void ApplyParameters(AbstractGeneratableObject gen)
        {
            Generated = gen;

            ((Region)Generated).GenerateSettlements();
        }
    }
}
