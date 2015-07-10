using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGE.Core.Generator;
using PGE.Fantasy_World.Lifeforms.Generation_Parameters;
using PGE.Fantasy_World.Lifeforms.Micro.Objects;
using PGE.Fantasy_World.Lifeforms.Objects;

namespace PGE.Fantasy_World.Tests.Lifeform_Tests
{
    [TestClass]
    public class TraitTest
    {
        [TestMethod]
        public void TestInheritance()
        {
            var genParams = new HumanoidBuilder();
            genParams.AddTrait(new Trait());

            var gen = new Generator<Humanoid>();
            gen.Add(genParams);

            var human = gen.Build();

            Assert.IsNotNull(human);
            Assert.IsNotNull(human.Traits);
        }

        // One thing I'm not certain about is how to match up the traits from father and mother
        // In the case that there's a mismatch, I guess we look to see its hereditary strength

        // Say that a father (w/ Heat Resistance) finds a mother (no traits) in the desert
            // Father + Mother yield offspring with Heat Resistance
            // Natural selection dictates that the offspring are better suited to survival
            // This is not necessarily the truth, as there are many factors... but we'll say it is.
            // The Heat Resistance trait should propagate throughout the generations
                // Heat Resistance means fewer check failures... Should attraction be dictated by success %?
                    // Most successful with the next most successful and so on and so forth
                    // Less ideal because this limits exposure of successful adaptations
    }
}
