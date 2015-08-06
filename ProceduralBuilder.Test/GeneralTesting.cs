using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralBuilder.Test.Objects;

namespace ProceduralBuilder.Test
{
    [TestClass]
    public class GeneralTesting
    {
        [TestMethod]
        public void ParentFlatBuild_LeavesChildrenEmpty()
        {
            dynamic parentBuilder = new ParentBuilder();
            var parent = parentBuilder
                .Flat()
                .Build();

            Assert.IsNotNull(parent);
            Assert.IsNotNull(parent.Children);
            Assert.IsTrue(parent.Children.Count == 0);
        }

        [TestMethod]
        public void ParentBuild_GeneratesSomeChildren()
        {
            dynamic parentBuilder = new ParentBuilder();
            var parent = parentBuilder
                .Build();

            Assert.IsNotNull(parent);
            Assert.IsNotNull(parent.Children);
            Assert.IsTrue(parent.Children.Count > 0);
        }

        [TestMethod]
        public void ParentBuildUntilChild_LeavesChildrenEmpty()
        {
            dynamic parentBuilder = new ParentBuilder();
            var parent = parentBuilder
                .Until(typeof (ChildModel))
                .Build();

            Assert.IsNotNull(parent);
            Assert.IsNotNull(parent.Children);
            Assert.IsTrue(parent.Children.Count == 0);
        }

        [TestMethod]
        public void ParentBuildWithChildren_UsesSpecifiedChildrenInsteadOfGenerating()
        {
            var children = new List<ChildModel>();
            for (var i = 0; i < 20; ++i) // Cannot generate 20 children
            {
                children.Add(new ChildBuilder()
                    .Build());
            }

            dynamic parentBuilder = new ParentBuilder();
            var parent = parentBuilder
                .WithChildren(children)
                .Build();

            Assert.IsNotNull(parent);
            Assert.IsNotNull(parent.Children);
            Assert.IsTrue(parent.Children.Count == 20);
        }

        [TestMethod]
        public void ParentBuild_GeneratesChildrenWithMultiplier()
        {
            const int multiplier = 4;

            dynamic parentBuilder = new ParentBuilder();
            var parent = parentBuilder
                .WithRangeMultiplier(multiplier)
                .IsResponsible(true)
                .Build();

            Assert.IsNotNull(parent);
            Assert.IsNotNull(parent.Children);
            Assert.IsTrue(parent.Children.Count > 0);

            foreach (var child in parent.Children)
            {
                Assert.IsTrue(child.Minimum >= multiplier * 4);
                Assert.IsTrue(child.Maximum > child.Minimum);
            }
        }
    }
}