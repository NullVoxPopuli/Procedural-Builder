using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGE.Core.Statistics;

namespace Generator_Core_Tests.Statistics
{
    [TestClass]
    public class DiceTests
    {
        [TestMethod]
        public void Roll_ShouldBeWithinBounds()
        {
            for (var i = 2; i < 100; i++)
            {
                Assert.IsTrue(i >= Dice.Roll(i));
            }
        }

        [TestMethod]
        public void PerformCheck_ShouldFailIfDCIsHigherThanPossible()
        {
            Assert.IsFalse( Dice.PerformCheck(-20, 0) );
            Assert.IsFalse( Dice.PerformCheck( 0, 20) );
        }

        [TestMethod]
        public void PerformCheck_ShouldPassIfDCIsEqualToOrLowerThanModifier()
        {
            for (var i = 0; i < 20; i++)
            {
                Assert.IsTrue(Dice.PerformCheck(i,i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void RollOnTable_ThrowsOnEmptyTable()
        {
            Dice.RollOnTable<string>(null);
        }

        [TestMethod]
        public void RollOnTable_ReturnsOneOfSeveralResults()
        {
            const string testString = "description";
            var exampleTable = new List<string>
            {
                testString
            };

            var result = Dice.RollOnTable(exampleTable);

            Assert.AreEqual(testString, result);
        }
    }
}
