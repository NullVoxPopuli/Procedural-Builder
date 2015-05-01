using System;
using System.Collections.Generic;
using System.Linq;

namespace PGE.Core.Statistics
{
    public static class Dice
    {
        private static readonly Random Rand = new Random();

        public static int Roll(int numSides)
        {
            return Rand.Next(numSides);
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
