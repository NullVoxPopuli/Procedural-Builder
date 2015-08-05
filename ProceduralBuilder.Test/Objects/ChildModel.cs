using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGenCore;
using PGenCore.Stochasticity;

namespace ProceduralBuilder.Test.Objects
{
    public class ChildModel : GeneratedModel
    {
        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public override void ProceduralBuild(GeneratedModel @from, Type until)
        {
            if (@from is ParentModel)
            {
                BuildFromParent((ParentModel) @from);
            }

            // Don't care about "until" because this is the final node
        }

        private void BuildFromParent(ParentModel from)
        {
            Minimum = from.RangeMultiplier * 4;
            Maximum = Minimum + 1 + Dice.Roll(4);
        }
    }
}
