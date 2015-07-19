using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGE.Core.Models;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Builders.Civilization;
using PGE.Fantasy_World.Models.Civilization;

namespace PGE.Fantasy_World.Models.World
{
    public class Region : GeneratedModel
    {
        public List<Settlement> Settlements;

        // Wind amount
        public double WindAmount;

        // Fauna Characteristics
        public double AverageRainfall;
        public double AverageTemperature;
        public double SoilNitrogenContent;
        public int HoursOfAvailableSunlight;
        public double SunlightConcentration;

        // Where -1.0 is completely unstable
        // 0.0 is standard seasons
        // 1.0 is a single season
        public double StabilityOfClimate;

        // Master Procedural-Build. Starts the chain of generation here
        public override void ProceduralBuild(Type until = null)
        {
            
        }

        // Linked Procedural Build. Continus in the chain of generation
        public override void ProceduralBuild(GeneratedModel from, Type until = null)
        {
            // Basic Checking
            if (from == null || from.GetType() != typeof(Landmass)) throw new Exception();

            var landmass = (Landmass)from;

            StabilityOfClimate = GenerateStabilityOfClimate(
                sizeOfRegion: landmass.ContinentSize, // Need something else for this, probably
                proximityToEquator: landmass.ProximityToEquator,
                variability: landmass.RegionDiversity);

            HoursOfAvailableSunlight = GenerateHoursOfAvailableSunlight(
                averageHoursOfSunlight: landmass.AverageHoursOfAvailableSunlight,
                proximityToEquator: landmass.ProximityToEquator,
                variability: landmass.RegionDiversity); // This is a regional average and is not governed by continental weather

            WindAmount = GenerateWindAmount(
                variability: StabilityOfClimate);

            AverageRainfall = GenerateAverageRainfall(
                averageRainfall: landmass.AverageRainfall,
                proximityToEquator: landmass.ProximityToEquator,
                variability: StabilityOfClimate);

            SunlightConcentration = GenerateSunlightConcentration(
                proximityToEquator: landmass.ProximityToEquator,
                averageRainfall: AverageRainfall,
                variability: StabilityOfClimate);

            SoilNitrogenContent = GenerateSoilNitrogenContent(
                rainFall: AverageRainfall,
                temperature: AverageTemperature,
                variability: StabilityOfClimate);

            AverageTemperature = GenerateAverageTemperature(
                averageHoursOfSunlight: landmass.AverageHoursOfAvailableSunlight,
                averageSunlightConcentration: landmass.AverageSunlightConcentration,
                averageTemperature: landmass.AverageTemperature,
                proximityToEquator: landmass.ProximityToEquator,
                variability: landmass.RegionDiversity); // This is a regional average and is not governed by continental weather

            SoilNitrogenContent = GenerateSoilNitrogenContent(
                rainFall: AverageRainfall,
                temperature: AverageTemperature,
                variability: StabilityOfClimate);

            Settlements = GenerateSettlements(until);
        }

        private List<Settlement> GenerateSettlements(Type until)
        {
            var settlements = new List<Settlement>();

            if (until != null)
            {
                if (typeof(Settlement) == until) return settlements;
            }

            var numberOfSettlements = Dice.Roll(numberOfSides: 4, numberOfTimes: 1); // Average of 2.5

            for (var i = 0; i < numberOfSettlements; ++i)
            {
                settlements.Add(new SettlementBuilder()
                    .Build(this, until));
            }

            return settlements;
        }

        private double GenerateSunlightConcentration(double proximityToEquator, double averageRainfall, double variability)
        {
            if (SunlightConcentration != Constants.DefaultInt) return SunlightConcentration;

            // TODO: How do we implement this...?
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: proximityToEquator - averageRainfall, standardDeviation: variability);
        }

        private double GenerateSoilNitrogenContent(double rainFall, double temperature, double variability)
        {
            if (SoilNitrogenContent != Constants.DefaultInt) return SoilNitrogenContent;

            // TODO: How do we implement this...?
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: rainFall + temperature, standardDeviation: variability);
        }

        private double GenerateStabilityOfClimate(double sizeOfRegion, double proximityToEquator, double variability)
        {
            if (StabilityOfClimate != Constants.DefaultInt) return StabilityOfClimate;

            // TODO: How do we implement this...?
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: variability, standardDeviation: variability);
        }

        private int GenerateHoursOfAvailableSunlight(int averageHoursOfSunlight, double proximityToEquator, double variability)
        {
            if (HoursOfAvailableSunlight != Constants.DefaultInt) return HoursOfAvailableSunlight;

            // TODO: "Average" should be 4 hours if 0.9 from equator, 8 hours if 0.5 from equator, and 12 hours if 0.0 from equator
            return Core.Statistics.Gaussian.GetGaussianRandomInt(mean: averageHoursOfSunlight, standardDeviation: variability);
        }

        private double GenerateAverageTemperature(int averageHoursOfSunlight, double averageSunlightConcentration,
            double averageTemperature, double proximityToEquator, double variability)
        {
            if (AverageTemperature != Constants.DefaultDouble) return AverageTemperature;

            // TODO: "Average" should be centered on 8 hours of sunlight at 0.5 concentration and 0.5 proximity to equator
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: averageTemperature, standardDeviation: variability);
        }

        private double GenerateAverageRainfall(double averageRainfall, double variability, double proximityToEquator)
        {
            if (averageRainfall != Constants.DefaultDouble) return averageRainfall;

            // TODO: the closer to the equator we are, the more rain we should be expected to get.
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: averageRainfall, standardDeviation: variability);
        }

        private double GenerateWindAmount(double variability)
        {
            if (WindAmount != Constants.DefaultDouble) return WindAmount;

            // TODO: What governs wind amount?
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: 0.5, standardDeviation: 0.2);
        }
    }
}
