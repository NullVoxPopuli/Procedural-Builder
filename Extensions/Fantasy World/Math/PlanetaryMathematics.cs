using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGE.Fantasy_World.Math
{
    public static class PlanetaryMathematics
    {
        public static double ThermalConductivity(
            double nitrogenContent, 
            double oxygenContent, 
            double carbonDioxideContent)
        {
            var nitrogenCoefficient = 0.32;
            var oxygenCoefficient = 0.025;
            var carbonDioxideCoefficient = 0.5;

            return oxygenContent*oxygenCoefficient
                   + carbonDioxideCoefficient*carbonDioxideContent
                   - nitrogenCoefficient*nitrogenContent;
        }

        public static double CalculatePercentageOfDay(
            double solarProximity, 
            double polarTilt, 
            double continentalProximityToEquator, 
            double orbitalSpeed)
        {
            // Orbital nonsense
            return 0.0;
        }
    }
}
