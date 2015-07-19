using System;
using System.Collections.Generic;
using PGE.Core.Models;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Builders.World;
using PGE.Fantasy_World.Math;

namespace PGE.Fantasy_World.Models.World
{
    public class Landmass : GeneratedModel
    {
        public List<Region> Regions;

        // Input parameters should examine the effects of the Planet on the landmass

        public double ContinentSize;

        // Where 0.0 is located on the equator
        // Where 1.0 is located at a pole
        public double ProximityToEquator;

        // Maximum number of Regions
        public int MaximumNumberOfRegions = 6;

        // Does this landmass have many environments, or is it just a single expansive region?
        // 0.0 = No Diversity
        // 1.0 = As many as <MaximumNumberOfRegions> Separate Regions
        public double RegionDiversity;

        // Average Rainfall and Temperature for this continent; used to drive Biome Generation in Regions
        // -1.0 == No Rain or Extremely Cold
        // 0.0 is roughly equivalent to temperate climates
        // 1.0 == Heavy, frequent rainfall; Extremely hot
        public double AverageRainfall;
        public double AverageTemperature;

        public double AverageSoilNitrogenContent;
        public int AverageHoursOfAvailableSunlight;
        public double AverageSunlightConcentration;

        public override void ProceduralBuild(Type until)
        {
            
        }

        public override void ProceduralBuild(GeneratedModel from, Type until = null)
        {
            var planet = (Planet)from;

            // Calculated Intermediaries
            var atmosphericThermalConductivity = PlanetaryMathematics.ThermalConductivity(
                nitrogenContent: planet.AtmosphericNitrogenPercent,
                oxygenContent: planet.AtmosphericOxygenPercent,
                carbonDioxideContent: planet.AtmosphericCarbonDioxidePercent);

            var percentageOfDay = PlanetaryMathematics.CalculatePercentageOfDay(
                solarProximity: planet.SolarProximityRelativeToEarth,
                polarTilt: planet.PolarTilt,
                continentalProximityToEquator: ProximityToEquator,
                orbitalSpeed: planet.OrbitalSpeedRelativeToEarth);

            var continentalSolarProximity = ContinentalMathematics.SolarProximity(
                planetSolarProximity: planet.SolarProximityRelativeToEarth,
                polarTilt: planet.PolarTilt,
                day: planet.DayOfYear,
                continentalProximityToEquator: ProximityToEquator);

            // Actual Calculations
            GenerateAverageRainfall(
                atmosphericOxygen: planet.AtmosphericOxygenPercent,
                continentalSolarProximity: planet.SolarProximityRelativeToEarth,
                size: planet.RadiusRelativeToEarth,
                amountOfWater: planet.AmountOfWaterRelativeToEarth,
                landWaterRatio: planet.LandWaterRatio);

            GenerateAverageTemperature(
                percentageOfDay: percentageOfDay,
                atmosphericThermalConductivity: atmosphericThermalConductivity,
                size: planet.RadiusRelativeToEarth,
                solarProximity: planet.SolarProximityRelativeToEarth,
                rainfall: AverageRainfall);

            if (Regions.Count == 0)
            {
                var numRegions = Dice.Roll(numberOfSides: 4, numberOfTimes: 1);

                for (var cont = 0; cont < numRegions; ++cont)
                {
                    var region = new RegionBuilder().Build();
                    region.ProceduralBuild(from: this, until: until);
                    Regions.Add(region);
                }
            }
        }

        private double GenerateAverageRainfall(double atmosphericOxygen, double continentalSolarProximity, double size, double amountOfWater, double landWaterRatio)
        {
            return 0.0;
        }

        public void GenerateAverageTemperature(double percentageOfDay, double atmosphericThermalConductivity,
            double size, double solarProximity, double rainfall)
        {
            AverageTemperature = ContinentalMathematics.AverageTemperature(
                atmosphericThermalConductivity: atmosphericThermalConductivity,
                continentSize: size,
                continentRainfall: rainfall,
                percentageOfDay: percentageOfDay,
                solarProximity: solarProximity);
        }
    }
}
