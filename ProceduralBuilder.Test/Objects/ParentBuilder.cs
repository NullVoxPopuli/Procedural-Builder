using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGenCore;

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
