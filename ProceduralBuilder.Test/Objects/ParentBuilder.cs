using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGenCore;
using PGenCore.Stochasticity;

namespace ProceduralBuilder.Test.Objects
{
    public class ParentBuilder : ProceduralBuilder<ParentModel>
    {
        private int _rangeMultiplier = 0;
        private List<ChildModel> _children; 

        protected override ParentModel BuildInitialModel()
        {
            return new ParentModel()
            {
                Children = _children,
                RangeMultiplier = _rangeMultiplier
            };
        }

        protected override void SetRelationshipDefaults()
        {
            if (_children == null)
            {
                _children = new List<ChildModel>();
            }
        }

        // Actual Procedural Generation
        protected override void ProcedurallyGenerate(ParentModel output)
        {
            if (_until != typeof(ChildModel))
            {
                GenerateChildren(output);
            }
        }

        private void GenerateChildren(ParentModel output)
        {
            if (output.Children.Count != 0) return;

            // Randomly generate 1-4 children
            var numChildren = Dice.Roll(numberOfSides: 4, numberOfTimes: 1) + 1;
            for (var cont = 0; cont < numChildren; ++cont)
            {
                output.Children.Add(new ChildBuilder()
                    .Using(output)
                    .Build());
            }
        }

        // Fluent Builders
        public ParentBuilder WithRangeMultiplier(int rangeMultiplier)
        {
            _rangeMultiplier = rangeMultiplier;
            return this;
        }

        public ParentBuilder WithChildren(List<ChildModel> children)
        {
            _children = children;
            return this;
        }
    }
}
