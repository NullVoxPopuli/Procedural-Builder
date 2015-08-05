using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGenCore;
using PGenCore.Stochasticity;

namespace ProceduralBuilder.Test.Objects
{
    public class ChildBuilder : ProceduralBuilder<ChildModel>
    {
        private int _minimum = 0;
        private int _maximum = 0;

        protected override void SetRelationshipDefaults() { }
        protected override ChildModel BuildInitialModel()
        {
            return new ChildModel()
            {
                Maximum = _maximum,
                Minimum = _minimum
            };
        }

        // Actual Procedural Generation
        protected override void ProcedurallyGenerate(ChildModel output)
        {
            if (_from is ParentModel)
            {
                GenerateFromParent(output);
            }
        }

        private void GenerateFromParent(ChildModel output)
        {
            output.Minimum = ((ParentModel)_from).RangeMultiplier * 4;
            output.Maximum = output.Minimum + 1 + Dice.Roll(4);
        }

        // Fluent Builders
        public ChildBuilder WithMinimum(int min)
        {
            _minimum = min;
            return this;
        }

        public ChildBuilder WithMaximum(int max)
        {
            _maximum = max;
            return this;
        }
    }
}
