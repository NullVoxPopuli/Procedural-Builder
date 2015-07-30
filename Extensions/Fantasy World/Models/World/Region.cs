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

        // This is used as a sort of a standard deviation used in Gaussian Random Fields
        public double StabilityOfClimate;

        public void ProceduralBuild(Model from, Type until = null)
        {
            // Basic Checking
            if (from == null || from.GetType() != typeof(Landmass)) throw new Exception();

            var landmass = (Landmass)from;

            GenerateStabilityOfClimate(
                sizeOfRegion: landmass.ContinentSize, // Need something else for this, probably
                proximityToEquator: landmass.ProximityToEquator,
                variability: landmass.RegionDiversity);

            GenerateHoursOfAvailableSunlight(
                averageHoursOfSunlight: landmass.AverageHoursOfAvailableSunlight,
                proximityToEquator: landmass.ProximityToEquator,
                variability: landmass.RegionDiversity); // This is a regional average and is not governed by continental weather

            GenerateWindAmount(
                variability: StabilityOfClimate);

            GenerateAverageRainfall(
                averageRainfall: landmass.AverageRainfall,
                proximityToEquator: landmass.ProximityToEquator,
                variability: StabilityOfClimate);

            GenerateSunlightConcentration(
                proximityToEquator: landmass.ProximityToEquator,
                averageRainfall: AverageRainfall,
                variability: StabilityOfClimate);

            GenerateSoilNitrogenContent(
                rainFall: AverageRainfall,
                temperature: AverageTemperature,
                variability: StabilityOfClimate);

            GenerateAverageTemperature(
                averageHoursOfSunlight: landmass.AverageHoursOfAvailableSunlight,
                averageSunlightConcentration: landmass.AverageSunlightConcentration,
                averageTemperature: landmass.AverageTemperature,
                proximityToEquator: landmass.ProximityToEquator,
                variability: landmass.RegionDiversity); // This is a regional average and is not governed by continental weather

            GenerateSoilNitrogenContent(
                rainFall: AverageRainfall,
                temperature: AverageTemperature,
                variability: StabilityOfClimate);

            // Finally, build the Region and then use it to drive Settlement Procedural Generation
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
                    .ProceduralBuild(this, until));
            }

            return settlements;
        }

        private void GenerateSunlightConcentration(double proximityToEquator, double averageRainfall, double variability)
        {
            if (SunlightConcentration == Constants.DefaultInt)
            {
                // TODO: How do we implement this...?
                SunlightConcentration = Core.Statistics.Gaussian.GetGaussianRandom(mean: proximityToEquator - averageRainfall, standardDeviation: variability);
            }
        }

        private void GenerateSoilNitrogenContent(double rainFall, double temperature, double variability)
        {
            if (SoilNitrogenContent == Constants.DefaultInt)
            {
                // TODO: How do we implement this...?
                SoilNitrogenContent = Core.Statistics.Gaussian.GetGaussianRandom(mean: rainFall + temperature, standardDeviation: variability);
            }
        }

        private void GenerateStabilityOfClimate(double sizeOfRegion, double proximityToEquator, double variability)
        {
            if (StabilityOfClimate == Constants.DefaultInt)
            {
                // TODO: How do we implement this...?
                StabilityOfClimate = Core.Statistics.Gaussian.GetGaussianRandom(mean: variability, standardDeviation: variability);
            }
        }

        private void GenerateHoursOfAvailableSunlight(int averageHoursOfSunlight, double proximityToEquator, double variability)
        {
            if (HoursOfAvailableSunlight == Constants.DefaultInt)
            {
                // TODO: "Average" should be 4 hours if 0.9 from equator, 8 hours if 0.5 from equator, and 12 hours if 0.0 from equator
                HoursOfAvailableSunlight = Core.Statistics.Gaussian.GetGaussianRandomInt(mean: averageHoursOfSunlight, standardDeviation: variability);
            }
        }

        private double GenerateAverageTemperature(int averageHoursOfSunlight, double averageSunlightConcentration,
            double averageTemperature, double proximityToEquator, double variability)
        {
            if (AverageRainfall != Constants.DefaultDouble) return AverageRainfall;

            // TODO: "Average" should be centered on 8 hours of sunlight at 0.5 concentration and 0.5 proximity to equator
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: averageTemperature, standardDeviation: variability);
        }

        private double GenerateAverageRainfall(double averageRainfall, double variability, double proximityToEquator)
        {
            if (AverageRainfall != Constants.DefaultDouble) return AverageRainfall;

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
