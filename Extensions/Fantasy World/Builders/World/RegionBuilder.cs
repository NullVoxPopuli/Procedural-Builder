using System;
using System.Collections.Generic;
using PGE.Core.Builder;
using PGE.Core.Models;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Builders.Civilization;
using PGE.Fantasy_World.Models.Civilization;
using PGE.Fantasy_World.Models.World;

namespace PGE.Fantasy_World.Builders.World
{
    public class RegionBuilder : IBuilder<Region>
    {
        private double _stabilityOfClimate = Constants.DefaultDouble;
        private double _windAmount = Constants.DefaultDouble;
        private double _sunlightConcentration = Constants.DefaultDouble;
        private double _soilNitrogenContent = Constants.DefaultDouble;
        private List<Settlement> _settlements;
        private int _hoursOfAvailableSunlight = Constants.DefaultInt;
        private double _averageTemperature = Constants.DefaultDouble;
        private double _averageRainfall = Constants.DefaultDouble;

        // Flat Building
        public Region Build()
        {
            SetRelationshipDefaults();

            return new Region()
            {
                AverageRainfall = _averageRainfall,
                AverageTemperature = _averageTemperature,
                HoursOfAvailableSunlight = _hoursOfAvailableSunlight,
                Settlements = _settlements,
                SoilNitrogenContent = _soilNitrogenContent,
                StabilityOfClimate = _stabilityOfClimate,
                SunlightConcentration = _sunlightConcentration,
                WindAmount = _windAmount
            };
        }

        public Region Build(Model @from, Type until = null)
        {
            var resultingRegion = Build();

            if (from.GetType() == typeof(Landmass))
            {
                resultingRegion.ProceduralBuild(from: from, until: until);
            }
            return resultingRegion;
        }

        public void SetRelationshipDefaults()
        {
            if (_settlements == null)
            {
                _settlements = new List<Settlement>();
            }
        }

        // Procedural Building
        public Region ProceduralBuild(GeneratedModel from, Type until = null)
        {
            // Basic Checking
            if (from == null || from.GetType() != typeof(Landmass)) throw new Exception();

            var landmass = (Landmass) from;
            
            _stabilityOfClimate = GenerateStabilityOfClimate(
                sizeOfRegion: landmass.ContinentSize, // Need something else for this, probably
                proximityToEquator: landmass.ProximityToEquator,
                variability: landmass.RegionDiversity);

            _hoursOfAvailableSunlight = GenerateHoursOfAvailableSunlight(
                averageHoursOfSunlight: landmass.AverageHoursOfAvailableSunlight,
                proximityToEquator: landmass.ProximityToEquator,
                variability: landmass.RegionDiversity); // This is a regional average and is not governed by continental weather

            _windAmount = GenerateWindAmount(
                variability: _stabilityOfClimate);

            _averageRainfall = GenerateAverageRainfall(
                averageRainfall: landmass.AverageRainfall,
                proximityToEquator: landmass.ProximityToEquator,
                variability: _stabilityOfClimate);

            _sunlightConcentration = GenerateSunlightConcentration(
                proximityToEquator: landmass.ProximityToEquator,
                averageRainfall: _averageRainfall,
                variability: _stabilityOfClimate);

            _soilNitrogenContent = GenerateSoilNitrogenContent(
                rainFall: _averageRainfall,
                temperature: _averageTemperature,
                variability: _stabilityOfClimate);

            _averageTemperature = GenerateAverageTemperature(
                averageHoursOfSunlight: landmass.AverageHoursOfAvailableSunlight,
                averageSunlightConcentration: landmass.AverageSunlightConcentration,
                averageTemperature: landmass.AverageTemperature,
                proximityToEquator: landmass.ProximityToEquator,
                variability: landmass.RegionDiversity); // This is a regional average and is not governed by continental weather

            _soilNitrogenContent = GenerateSoilNitrogenContent(
                rainFall: _averageRainfall,
                temperature: _averageTemperature,
                variability: _stabilityOfClimate);

            // Finally, build the Region and then use it to drive Settlement Procedural Generation
            var generatedRegion = Build();
            generatedRegion.Settlements = GenerateSettlements(generatedRegion, until);

            return generatedRegion;
        }

        private static List<Settlement> GenerateSettlements(Region generatedRegion, Type until)
        {
            var settlements = new List<Settlement>();

            if (until != null)
            {
                if (typeof(Settlement) == until) return settlements;
            }

            var numberOfSettlements = Dice.Roll(numberOfSides:4,numberOfTimes:1); // Average of 2.5

            for (var i = 0; i < numberOfSettlements; ++i)
            {
                settlements.Add(new SettlementBuilder()
                    .ProceduralBuild(generatedRegion, until));
            }

            return settlements;
        }

        private double GenerateSunlightConcentration(double proximityToEquator, double averageRainfall, double variability)
        {
            if (_sunlightConcentration != Constants.DefaultInt) return _sunlightConcentration;

            // TODO: How do we implement this...?
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: proximityToEquator - averageRainfall, standardDeviation: variability);
        }

        private double GenerateSoilNitrogenContent(double rainFall, double temperature, double variability)
        {
            if (_soilNitrogenContent != Constants.DefaultInt) return _soilNitrogenContent;

            // TODO: How do we implement this...?
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: rainFall + temperature, standardDeviation: variability);
        }

        private double GenerateStabilityOfClimate(double sizeOfRegion, double proximityToEquator, double variability)
        {
            if (_stabilityOfClimate != Constants.DefaultInt) return _stabilityOfClimate;

            // TODO: How do we implement this...?
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: variability, standardDeviation: variability);
        }

        private int GenerateHoursOfAvailableSunlight(int averageHoursOfSunlight, double proximityToEquator, double variability)
        {
            if (_hoursOfAvailableSunlight != Constants.DefaultInt) return _hoursOfAvailableSunlight;

            // TODO: "Average" should be 4 hours if 0.9 from equator, 8 hours if 0.5 from equator, and 12 hours if 0.0 from equator
            return Core.Statistics.Gaussian.GetGaussianRandomInt(mean: averageHoursOfSunlight, standardDeviation: variability);
        }

        private double GenerateAverageTemperature(int averageHoursOfSunlight, double averageSunlightConcentration,
            double averageTemperature, double proximityToEquator, double variability)
        {
            if (_averageTemperature != Constants.DefaultDouble) return _averageTemperature;

            // TODO: "Average" should be centered on 8 hours of sunlight at 0.5 concentration and 0.5 proximity to equator
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: averageTemperature, standardDeviation: variability);
        }

        private double GenerateAverageRainfall(double averageRainfall, double variability, double proximityToEquator)
        {
            if (_averageRainfall != Constants.DefaultDouble) return _averageRainfall;

            // TODO: the closer to the equator we are, the more rain we should be expected to get.
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: averageRainfall, standardDeviation: variability);
        }

        private double GenerateWindAmount(double variability)
        {
            if (_windAmount != Constants.DefaultDouble) return _windAmount;

            // TODO: What governs wind amount?
            return Core.Statistics.Gaussian.GetGaussianRandom(mean: 0.5, standardDeviation: 0.2);
        }

        // FLUENT BUILDER HELPERS
        public RegionBuilder WithWindAmount(double wind)
        {
            _windAmount = wind;
            return this;
        }

        public RegionBuilder WithSunlightConcentration(double concentration)
        {
            _sunlightConcentration = concentration;
            return this;
        }

        public RegionBuilder WithStabilityOfClimate(double stability)
        {
            _stabilityOfClimate = stability;
            return this;
        }

        public RegionBuilder WithSoilNitrogenContent(double content)
        {
            _soilNitrogenContent = content;
            return this;
        }

        public RegionBuilder WithHoursOfAvailableSunlight(int hours)
        {
            _hoursOfAvailableSunlight = hours;
            return this;
        }

        public RegionBuilder WithAverageTemperature(double temp)
        {
            _averageTemperature = temp;
            return this;
        }

        public RegionBuilder WithAverageRainfall(double rainfall)
        {
            _averageRainfall = rainfall;
            return this;
        }
    }
}
