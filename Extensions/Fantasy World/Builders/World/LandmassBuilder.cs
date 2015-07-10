using System.Collections.Generic;
using PGE.Core.Builder;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Models.World;

namespace PGE.Fantasy_World.Builders.World
{
    public class LandmassBuilder : IBuilder<Landmass>
    {
        public Landmass Build()
        {
            return new Landmass()
            {
                AverageHoursOfAvailableSunlight = 0,
                AverageRainfall = 0.0,
                AverageSoilNitrogenContent = 0.0,
                AverageSunlightConcentration = 0.0,
                AverageTemperature = 0.0,
                ContinentSize = 0.0,
                Description = "",
                MaximumNumberOfRegions = 0,
                Name = "",
                ProximityToEquator = 0.0,
                RegionDiversity = 0.0,
                Regions = new List<Region>()
            };
        }

        public void SetRelationshipDefaults()
        {
            throw new System.NotImplementedException();
        }

        //public override void ApplyParameters(AbstractGeneratableObject gen)
        //{
        //    Generated = gen;
        //
        //    ((Landmass)Generated).GenerateRegions();
        //}
        //
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
