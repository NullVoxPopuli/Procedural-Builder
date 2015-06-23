﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE.Core.Statistics
{
    public static class Gaussian
    {
        private static readonly Random Rand = new Random();

        public static double GetGaussianRandom(double mean, double standardDeviation)
        {
            var randomValue = 4*Rand.NextDouble() - 2.0;

            return mean + randomValue*standardDeviation;
        }

        public static int GetGaussianRandomInt(int mean, double standardDeviation)
        {
            var randomValue = 4 * Rand.Next() - 2.0;

            return (int) (mean + randomValue * standardDeviation);
        }

        public static double GetStandardDeviation(double mean, double ninetyFifthPercentile)
        {
            return (ninetyFifthPercentile - mean) / 4;
        }
    }
}
