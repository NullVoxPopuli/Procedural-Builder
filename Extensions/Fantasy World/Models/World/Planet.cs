using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using PGE.Core.Models;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Builders.World;

namespace PGE.Fantasy_World.Models.World
{
    public class Planet : GeneratedModel
    {
        public List<Landmass> Continents;
        
        // Atmosphere and resource availability
        public double AtmosphericNitrogenPercent;       // Earth's N2:  78.1%
        public double AtmosphericOxygenPercent;         // Earth's O2:  20.9%
        public double AtmosphericCarbonDioxidePercent;  // Earth's CO2: 0.03%
        public double LandWaterRatio;                   // Earth: 29% Land

        public double PolarTilt;
        public double OrbitalMajorAxis;                 // The large axis of an ellipsoid
        public double OrbitalMinorAxis;                 // The small axis of an ellipsoid
        public double OrbitalRotation;                  // The rotation of the major axis relative to day zero (see below)
        public double OrbitalOffset;                    // The offset on the major axis
        public double OrbitalSpeedRelativeToEarth;      // 1.0 would be 365.25 days

        public double RotationalSpeedRelativeToEarth;
        public double MassRelativeToEarth;
        public double RadiusRelativeToEarth;
        public double SolarProximityRelativeToEarth;
        public double AmountOfWaterRelativeToEarth;  // Unbounded, always positive

        // How do the continents connect?
        // -1.0 being completely together, like Pangea
        // 0.0 being where we are with the continents now on Earth
        // 1.0 being spread apart with each continent as its own island
        public double ContinentSpread;

        // Assumptions: Day Zero is when a positive polar tilt is exactly normal to the orbital line
        public double DayOfYear { get; private set; }

        public override void ProceduralBuild(Type until = null)
        {
            if (Continents.Count == 0)
            {
                var numContinents = Dice.Roll(numberOfSides: 4, numberOfTimes: 2);
                
                for (var cont = 0; cont < numContinents; ++cont)
                {
                    var continent = new LandmassBuilder().Build();
                    continent.ProceduralBuild(from: this, until: until);
                    Continents.Add(continent);
                }
            }
        }

        public override void ProceduralBuild(GeneratedModel @from, Type until)
        {
            // Since this is master, it cannot use an input
            ProceduralBuild(until);
        }
    }
}
