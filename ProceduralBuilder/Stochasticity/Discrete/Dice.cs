using System;
using System.Collections.Generic;
using System.Linq;

namespace PGenCore.Stochasticity.Discrete
{
    public static class Dice
    {
        private static readonly Random Rand = new Random();

        public static int Roll(int numberOfSides)
        {
            return Rand.Next(numberOfSides);
        }

        public static int Roll(int numberOfSides, int numberOfTimes)
        {
            var total = 0;

            for (var i = 0; i < numberOfTimes; ++i)
            {
                total += Roll(numberOfSides);
            }

            return total;
        }

        public static bool PerformCheck(int modifier, int dc)
        {
            var rollResult = Roll(20);

            return (rollResult + modifier) >= dc;
        }

        public static T RollOnTable<T>(IReadOnlyCollection<T> table)
        {
            var roll = Roll(table.Count);

            return table.ElementAt(roll);
        }
    }
}
