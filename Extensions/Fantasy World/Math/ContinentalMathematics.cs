using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE.Fantasy_World.Math
{
    public static class ContinentalMathematics
    {
        public static double AverageTemperature(double atmosphericThermalConductivity, double continentSize,
            double continentRainfall, double percentageOfDay, double solarProximity)
        {
            var atmosphereCoefficient = 1.0; // TBD 
            var proximityCoefficient = 1.0;  // TBD 
            var rainfallCoefficient = 1.0;   // TBD 
            var sizeCoefficient = 1.0;       // TBD 

            return atmosphereCoefficient * atmosphericThermalConductivity
                   + sizeCoefficient * continentSize
                   + rainfallCoefficient * continentRainfall
                   + proximityCoefficient * percentageOfDay * solarProximity;
        }
    }
}
