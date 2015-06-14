using Generator_Core_Tests.Generatable_Test_Items;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGE.Core.Generator;

namespace Generator_Core_Tests.Generator
{
    [TestClass]
    public class GeneratorTest
    {
        [TestMethod]
        public void Generator_BuildGeneric()
        {
            var gen = new Generator<TestGenerated>();

            var results = gen.Build();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.GetType() == typeof(TestGenerated));
        }

        [TestMethod]
        public void Generator_BuildGenericWithAdd()
        {
            var gen = new Generator<TestGenerated>();

            gen.Add(new TestGenerationParameters());

            var results = gen.Build();

            Assert.IsNotNull(results);
            Assert.IsTrue(results.GetType() == typeof(TestGenerated));
            Assert.AreEqual("Description",results.Description);
        }
    }
}
