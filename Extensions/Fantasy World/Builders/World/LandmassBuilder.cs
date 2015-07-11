using System.Collections.Generic;
using PGE.Core.Builder;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Models.World;

namespace PGE.Fantasy_World.Builders.World
{
    public class LandmassBuilder : IBuilder<Landmass>
    {
        private int _averageHoursOfAvailableSunlight = 0;
        private List<Region> _regions = new List<Region>();
        private double _regionDiversity = 0.0;
        private double _proximityToEquator = 0.0;
        private string _name = "";
        private int _maximumNumberOfRegions = 0;
        private string _description = "";
        private double _continentSize = 0.0;
        private double _averageTemperature = 0.0;
        private double _averageSunlightConcentration = 0.0;
        private double _averageSoilNitrogenContent = 0.0;
        private double _averageRainfall = 0.0;

        public LandmassBuilder WithAverageHoursOfAvailableSunlight(int hours)
        {
            _averageHoursOfAvailableSunlight = hours;
            return this;
        }

        public LandmassBuilder WithRegions(List<Region> regions)
        {
            _regions = regions;
            return this;
        }

        public LandmassBuilder WithRegionDiversity(double diversity)
        {
            _regionDiversity = diversity;

            return this;
        }

        public LandmassBuilder WithProximityToEquator(double prox)
        {
            _proximityToEquator = prox;
            return this;
        }

        public LandmassBuilder WithMaximumNumberOfRegions(int number)
        {
            _maximumNumberOfRegions = number;
            return this;
        }

        public LandmassBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public LandmassBuilder WithDescription(string desc)
        {
            _description = desc;
            return this;
        }

        public LandmassBuilder WithContinentSize(double size)
        {
            _continentSize = size;
            return this;
        }

        public LandmassBuilder WithAverageTemperature(double temp)
        {
            _averageTemperature = temp;
            return this;
        }

        public LandmassBuilder WithAverageSunlightConcentration(double concentration)
        {
            _averageSunlightConcentration = concentration;
            return this;
        }

        public LandmassBuilder WithAverageSoilNitrogenContent(double average)
        {
            _averageSoilNitrogenContent = average;
            return this;
        }

        public LandmassBuilder WithAverageRainfall(double average)
        {
            _averageRainfall = average;
            return this;
        }

        public Landmass Build()
        {
            SetRelationshipDefaults();

            return new Landmass()
            {
                AverageHoursOfAvailableSunlight = _averageHoursOfAvailableSunlight,
                AverageRainfall = _averageRainfall,
                AverageSoilNitrogenContent = _averageSoilNitrogenContent,
                AverageSunlightConcentration = _averageSunlightConcentration,
                AverageTemperature = _averageTemperature,
                ContinentSize = _continentSize,
                Description = _description,
                MaximumNumberOfRegions = _maximumNumberOfRegions,
                Name = _name,
                ProximityToEquator = _proximityToEquator,
                RegionDiversity = _regionDiversity,
                Regions = _regions
            };
        }

        public void SetRelationshipDefaults()
        {
            if (_regions == null)
            {
                _regions = new List<Region>();
            }
        }

        public void DoProceduralGeneration(Planet model)
        {
            if (_regions == null)
            {
                _ //asdf
                return;
            }
        }

        //public void CalculateLocationAndSize()
        //{
        //    ((Landmass)Generated).ContinentSize = Gaussian.GetGaussianRandom(
        //        mean: 0.5,
        //        standardDeviation: 0.1);
        //
        //    ((Landmass)Generated).ProximityToEquator = Gaussian.GetGaussianRandom(
        //        mean: 0.5,
        //        standardDeviation: 0.25);
        //}
        //
        //// TODO: Region Diversity is hardcoded for now, should be specified by certain parameters... need to figure those out
        //public void CalculateAverages(Models.World.Planet.Season currentSeason, double globalTemperature, double globalRainfall)
        //{
        //    // Region Diversity
        //    CalculateDiversity();
        //
        //    // Average Rainfall
        //    ((Landmass)Generated).AverageRainfall = Gaussian.GetGaussianRandom(
        //        mean: globalRainfall,
        //        standardDeviation: ((Landmass)Generated).RegionDiversity);
        //
        //    // Average Temperature
        //    ((Landmass) Generated).AverageTemperature = Gaussian.GetGaussianRandom(
        //        mean: globalTemperature,
        //        standardDeviation: ((Landmass) Generated).RegionDiversity);
        //    ((Landmass) Generated).AverageTemperature *= ((Landmass) Generated).ProximityToEquator;
        //
        //    ApplySeasonToAverages(currentSeason);
        //}
        //
        //private void CalculateDiversity()
        //{
        //    ((Landmass) Generated).RegionDiversity = Gaussian.GetGaussianRandom(
        //        mean: ((Landmass) Generated).ContinentSize,
        //        standardDeviation: 0.2);
        //}
        //
        //// TODO: Hours should be dictated by how close Landmass is to Equator and the planet's Solar Proximity
        //private void ApplySeasonToAverages(Models.World.Planet.Season currentSeason)
        //{
        //    switch (currentSeason)
        //    {
        //        case Models.World.Planet.Season.Spring:
        //            ApplySpring();
        //            break;
        //
        //        case Models.World.Planet.Season.Summer:
        //            ApplySummer();
        //            break;
        //
        //        case Models.World.Planet.Season.Autumn:
        //            ApplyAutumn();
        //            break;
        //
        //        case Models.World.Planet.Season.Winter:
        //            ApplyWinter();
        //            break;
        //    }
        //}
        //
        //private void ApplyWinter()
        //{
        //    ((Landmass) Generated).AverageRainfall -= 0.1;
        //    ((Landmass) Generated).AverageTemperature -= 0.4;
        //
        //    // Average Hours Of Available Sunlight
        //    ((Landmass)Generated).AverageHoursOfAvailableSunlight = Gaussian.GetGaussianRandomInt(
        //        mean: 6,
        //        standardDeviation: ((Landmass)Generated).RegionDiversity);
        //
        //    // Sunlight Energy Concentration
        //    ((Landmass)Generated).AverageSunlightConcentration = Gaussian.GetGaussianRandom(
        //        mean: -0.3,
        //        standardDeviation: ((Landmass)Generated).RegionDiversity);
        //}
        //
        //private void ApplyAutumn()
        //{
        //    ((Landmass) Generated).AverageRainfall += 0.1;
        //    ((Landmass) Generated).AverageTemperature -= 0.05;
        //
        //    // Average Hours Of Available Sunlight
        //    ((Landmass)Generated).AverageHoursOfAvailableSunlight = Gaussian.GetGaussianRandomInt(
        //        mean: 8,
        //        standardDeviation: ((Landmass)Generated).RegionDiversity);
        //
        //    // Sunlight Energy Concentration
        //    ((Landmass)Generated).AverageSunlightConcentration = Gaussian.GetGaussianRandom(
        //        mean: 0.1,
        //        standardDeviation: ((Landmass)Generated).RegionDiversity);
        //}
        //
        //private void ApplySummer()
        //{
        //    ((Landmass) Generated).AverageRainfall += 0.1;
        //    ((Landmass) Generated).AverageTemperature += 0.3;
        //
        //    // Average Hours Of Available Sunlight
        //    ((Landmass)Generated).AverageHoursOfAvailableSunlight = Gaussian.GetGaussianRandomInt(
        //        mean: 12,
        //        standardDeviation: ((Landmass)Generated).RegionDiversity);
        //
        //    // Sunlight Energy Concentration
        //    ((Landmass)Generated).AverageSunlightConcentration = Gaussian.GetGaussianRandom(
        //        mean: 0.5,
        //        standardDeviation: ((Landmass)Generated).RegionDiversity);
        //}
        //
        //private void ApplySpring()
        //{
        //    ((Landmass)Generated).AverageRainfall += 0.2;
        //
        //    // Average Hours Of Available Sunlight
        //    ((Landmass)Generated).AverageHoursOfAvailableSunlight = Gaussian.GetGaussianRandomInt(
        //        mean: 9,
        //        standardDeviation: ((Landmass)Generated).RegionDiversity);
        //
        //    // Sunlight Energy Concentration
        //    ((Landmass)Generated).AverageSunlightConcentration = Gaussian.GetGaussianRandom(
        //        mean: 0.2,
        //        standardDeviation: ((Landmass)Generated).RegionDiversity);
        //}
    }
}
