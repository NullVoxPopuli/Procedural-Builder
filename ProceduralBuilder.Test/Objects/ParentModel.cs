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
        public IList<ChildModel> Children { get; set; } 

        public override void ProceduralBuild(GeneratedModel @from, Type until)
        {
            // Don't care about @from here since this is Origin Link

            if (until != typeof(ChildModel))
            {
                GenerateChildren();
            }
        }

        private void GenerateChildren()
        {
            if (Children.Count != 0) return;

            // Randomly generate 1-4 children
            var numChildren = Dice.Roll(numberOfSides: 4, numberOfTimes: 1) + 1;
            for (var cont = 0; cont < numChildren; ++cont)
            {
                Children.Add(new ChildBuilder()
                    .Using(this)
                    .Build());
            }
        }
    }
}
