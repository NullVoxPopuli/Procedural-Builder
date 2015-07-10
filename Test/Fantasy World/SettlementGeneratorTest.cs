using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGE.Core.Generator;
using PGE.Fantasy_World.Civilization.Macro.Generation_Parameters;
using PGE.Fantasy_World.Civilization.Macro.Objects;

namespace PGE.Fantasy_World.Tests
{
    [TestClass]
    public class SettlementGeneratorTest
    {
        [TestMethod]
        public void GenerateTest()
        {
            var gen = new Generator<Settlement>();
            var generationParams = new SettlementBuilder();
        
            gen.Add(generationParams);
            var generatedSettlement = gen.Build();

            Assert.IsNotNull(generatedSettlement);
        }
    }
}
