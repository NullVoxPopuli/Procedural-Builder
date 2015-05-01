using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGE.Core.Generated_Items;
using PGE.Fantasy_World.Lifeforms.Objects;

namespace PGE.Fantasy_World.Lifeforms.Micro.Objects
{
    // Describes an effect to a lifeform
    public class Trait : IGeneratable
    {
        public HereditaryType HereditaryNature;
        public double EffectStrength;

        #region Genetics

        private readonly Trait[] _inheritedTraits;
        private const int MaxTraitDepth = 4;

        #endregion
        #region Constructors

        public Trait()
        {
            _inheritedTraits = new Trait[2];
        }

        private Trait(Trait maleTrait, Trait femaleTrait)
        {
            _inheritedTraits = new [] { maleTrait, femaleTrait };
        }

        #endregion
        #region Singular DoEffect() and Recursive DoMergedEffect()

        /// <summary>
        /// Singular version of trait effect application.
        /// </summary>
        /// <param name="target"></param>
        public void DoEffect(Humanoid target)
        {

        }

        /// <summary>
        /// Entry point of heriditary trait effect application. Calls on inherited traits to do their 
        /// Merged Effects as well
        /// </summary>
        /// <param name="target"></param>
        public virtual void DoMergedEffect(Humanoid target)
        {
            DoMergedEffect(target, 0);
        }

        protected virtual void DoMergedEffect(Humanoid target, int depth)
        {
            DoEffect(target);

            if (++depth > MaxTraitDepth)
            {
                // Kill off any subsequent traits in case they exist
                // Does this force garbage collection?
                _inheritedTraits[0] = null;
                _inheritedTraits[1] = null;
                
                return;
            }

            if (_inheritedTraits[0] != null)
            {
                _inheritedTraits[0].DoMergedEffect(target, depth);
            }

            if (_inheritedTraits[1] != null)
            {
                _inheritedTraits[1].DoMergedEffect(target, depth);
            }
        }

        #endregion

        // Can play around with this a bit, depending on the HeritaryNature of each...
        public static Trait Merge(Trait maleTrait, Trait femaleTrait)
        {
            var totalEffectPercentage = maleTrait.EffectStrength + femaleTrait.EffectStrength;

            maleTrait.EffectStrength /= totalEffectPercentage;
            femaleTrait.EffectStrength /= totalEffectPercentage;

            return new Trait(maleTrait, femaleTrait);
        }
    }

    public enum HereditaryType
    {
        CompleteDominant, IncompleteDominant, CoDominant, Recessive
    }
}
