using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGenCore;

namespace ProceduralBuilder.Test.Objects
{
    public class ChildBuilder : ProceduralBuilder<ChildModel>
    {
        private int _minimum = 0;
        private int _maximum = 0;

        protected override ChildModel BuildInitialModel()
        {
            return new ChildModel()
            {
                Maximum = _maximum,
                Minimum = _minimum
            };
        }

        protected override void SetRelationshipDefaults() {}

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
