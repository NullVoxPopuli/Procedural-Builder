﻿using System.CodeDom.Compiler;
using System.Collections.Generic;
using PGE.Core.Models;
using PGE.Core.Statistics;
using PGE.Fantasy_World.World.Builders;

namespace PGE.Fantasy_World.Models.World
{
    public class World : Model
    {
        public List<Landmass> Continents;

        // Procedural Generation parameters should include anything that discusses the planet as a whole. For instance...

        // How close is it to the sun? 
        // -1.0 being closer than normal (like Venus) 
        // 0.0 being completely even with Earth's orbit
        // 1.0 being further than normal (like Mars)
        public double ProximityToSolarEntity;

        // Atmosphere and resource availability
        public double AtmosphericNitrogenPercent;       // Earth's N2:  78.1%
        public double AtmosphericOxygenPercent;         // Earth's O2:  20.9%
        public double AtmosphericCarbonDioxidePercent;  // Earth's CO2: 0.03%
        public double PercentageOfLand;                 // Earth: 29% Land
        public double AbundanceOfWaterRelativeToEarth;  // Unbounded, always positive

        // What season is it? // TODO: move somewhere else, like biome
        public enum Season
        {
            Winter, Spring, Summer, Autumn
        };
        public Season CurrentSeason;

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

        //public void GenerateContinents()
        //{
        //    Continents = new List<Landmass>();
        //
        //    // This gives us 5 continents on average
        //    var numberOfContinents = Dice.Roll(
        //        numberOfSides: 4,
        //        numberOfTimes: 2);
        //
        //    // Prepare the basic Build Parameters for the Landmasses using our statistics
        //    var generator = new Generator<Landmass>();
        //    var continentParams = new LandmassBuilder();
        //    generator.Add(continentParams);
        //
        //    for (var continentIndex = 0; continentIndex < numberOfContinents; ++continentIndex)
        //    {
        //        continentParams.CalculateLocationAndSize();
        //
        //        continentParams.CalculateAverages(
        //            currentSeason: CurrentSeason,
        //            globalRainfall: GlobalAverageRainfall,
        //            globalTemperature: GlobalAverageTemperature);
        //
        //        Continents.Add(generator.Build());
        //    }
        //}
    }
}