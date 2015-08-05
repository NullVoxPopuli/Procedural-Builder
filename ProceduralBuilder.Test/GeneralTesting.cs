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
            var parent = new ParentBuilder()
                .Flat()
                .Build();

            Assert.IsNotNull(parent);
            Assert.IsNotNull(parent.Children);
            Assert.IsTrue(parent.Children.Count == 0);
        }

        [TestMethod]
        public void ParentBuild_GeneratesSomeChildren()
        {
            var parent = new ParentBuilder()
                .Build();

            Assert.IsNotNull(parent);
            Assert.IsNotNull(parent.Children);
            Assert.IsTrue(parent.Children.Count > 0);
        }

        [TestMethod]
        public void ParentBuildUntilChild_LeavesChildrenEmpty()
        {
            var parent = new ParentBuilder()
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

            var parent = new ParentBuilder()
                .WithChildren(children)
                .Build();

            Assert.IsNotNull(parent);
            Assert.IsNotNull(parent.Children);
            Assert.IsTrue(parent.Children.Count == 20);
        }

        [TestMethod]
        public void ParentBuild_GeneratesChildrenWithMultiplier()
        {
            var multiplier = 4;

            var parent = new ParentBuilder()
                .WithRangeMultiplier(multiplier)
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