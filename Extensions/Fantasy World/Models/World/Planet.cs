using System.CodeDom.Compiler;
using System.Collections.Generic;
using PGE.Core.Models;
using PGE.Core.Statistics;

namespace PGE.Fantasy_World.Models.World
{
    public class Planet : GeneratedModel
    {
        public List<Landmass> Continents;
        
        // Atmosphere and resource availability
        public double AtmosphericNitrogenPercent;       // Earth's N2:  78.1%
        public double AtmosphericOxygenPercent;         // Earth's O2:  20.9%
        public double AtmosphericCarbonDioxidePercent;  // Earth's CO2: 0.03%
        public double PercentageOfLand;                 // Earth: 29% Land

        public double PolarTilt;
        public double EllipsoidalOrbit; // 0.0 is perfectly circular, then the major axis increases alongside the value
        public double OrbitalSpeedRelativeToEarth;
        public double RotationalSpeedRelativeToEarth;
        public double MassRelativeToEarth;
        public double RadiusRelativeToEarth;
        public double SolarProximityRelativeToEarth;
        public double AbundanceOfWaterRelativeToEarth;  // Unbounded, always positive

        // Does the planet have a predisposition to warmer climates?
        // -1.0 Much colder than normal
        // 0.0 even with Earth
        // 1.0 Much warmer than normal
        public double GlobalAverageRainfall;
        public double GlobalAverageTemperature;

        // How do the continents connect?
        // -1.0 being completely together, like Pangea
        // 0.0 being where we are with the continents now on Earth
        // 1.0 being spread apart with each continent as its own island
        public double ContinentSpread;
    }
}
