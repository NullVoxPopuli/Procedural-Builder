using System.Collections.Generic;
using PGenCore;

namespace ProceduralBuilder.Test.Objects
{
    public class DynamicParentBuilder : DynamicBuilder<ParentModel>
    {
        private int _rangeMultiplier = 0;
        private List<ChildModel> _children;
        private bool _isResponsible = false;

        public override ParentModel Build()
        {
            return new ParentModel()
            {
                Children = _children,
                RangeMultiplier = _rangeMultiplier,
                IsResponsible = _isResponsible
            };
        }

        public override void SetRelationshipDefaults()
        {
            if (_children == null)
            {
                _children = new List<ChildModel>();
            }
        }
    }
}