using Microsoft.CSharp.RuntimeBinder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProceduralBuilder.Test.Objects;

namespace ProceduralBuilder.Test
{
    [TestClass]
    public class DynamicBuidlderTest
    {

        [TestMethod]
        public void MethodInvocation_OfField()
        {
            dynamic parentBuilder = new DynamicParentBuilder();
            var parent = parentBuilder
                .WithRangeMultiplier(2)
                .Build();

            Assert.AreEqual(
                actual: parent.RangeMultiplier,
                expected: 2);
        }

        [TestMethod]
        public void MethodInvocation_OfNonField()
        {
            dynamic parentBuilder = new DynamicParentBuilder();
            var parentBuilderType = parentBuilder.GetType();

            Assert.AreEqual(
                actual: parentBuilderType,
                expected: typeof(DynamicParentBuilder));
        }

        [TestMethod]
        [ExpectedException(typeof(RuntimeBinderException))]
        public void MethodInvocation_OfNonExistantMethod()
        {
            dynamic parentBuilder = new DynamicParentBuilder();
            parentBuilder.WithNonExistantMethod(null);
        }

        [TestMethod]
        public void MethodInvocation_OfBoolean()
        {
            dynamic parentBuilder = new DynamicParentBuilder();
            var parent = parentBuilder
                .IsResponsible(true)
                .Build();

            Assert.AreEqual(
                actual: parent.IsResponsible,
                expected: true);
        }
    }
}
