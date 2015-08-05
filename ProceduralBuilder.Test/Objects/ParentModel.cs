using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGenCore;
using PGenCore.Stochasticity;

namespace ProceduralBuilder.Test.Objects
{
    public class ParentModel : GeneratedModel
    {
        public int RangeMultiplier { get; set; }
        public bool IsResponsible { get; set; }
        public IList<ChildModel> Children { get; set; }
    }
}
