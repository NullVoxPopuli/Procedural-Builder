using PGE.Core.Generated_Items;
using PGE.Core.Statistics;
using PGE.Fantasy_World.World.Objects;

namespace PGE.Fantasy_World.World.Generation_Parameters
{
    public class LandmassGenerationParameters : GenerationParameters
    {
        public override void ApplyParameters(AbstractGeneratableObject gen)
        {
            Generated = gen;

            ((Landmass)Generated).GenerateRegions();
        }

        // TODO: Region Diversity is hardcoded for now, should be specified by certain parameters... need to figure those out
        public void CalculateAverages(Objects.World.Season currentSeason, double globalTemperature, double globalRainfall)
        {
            // Region Diversity
            ((Landmass)Generated).RegionDiversity = Gaussian.GetGaussianRandom(
                mean: 0.5, 
                standardDeviation: 0.1);

            // Average Rainfall
            ((Landmass)Generated).AverageRainfall = Gaussian.GetGaussianRandom(
                mean: globalRainfall,
                standardDeviation: ((Landmass)Generated).RegionDiversity);

            // Average Temperature
            ((Landmass)Generated).AverageTemperature = Gaussian.GetGaussianRandom(
                mean: globalTemperature,
                standardDeviation: ((Landmass)Generated).RegionDiversity);

            ApplySeasonToAverages(currentSeason);
        }

        // TODO: Hours should be dictated by how close Landmass is to Equator and the planet's Solar Proximity
        private void ApplySeasonToAverages(Objects.World.Season currentSeason)
        {
            switch (currentSeason)
            {
                case Objects.World.Season.Spring:
                    ApplySpring();
                    break;

                case Objects.World.Season.Summer:
                    ApplySummer();
                    break;

                case Objects.World.Season.Autumn:
                    ApplyAutumn();
                    break;

                case Objects.World.Season.Winter:
                    ApplyWinter();
                    break;
            }
        }

        private void ApplyWinter()
        {
            ((Landmass) Generated).AverageRainfall -= 0.1;
            ((Landmass) Generated).AverageTemperature -= 0.4;

            // Average Hours Of Available Sunlight
            ((Landmass)Generated).AverageHoursOfAvailableSunlight = Gaussian.GetGaussianRandomInt(
                mean: 6,
                standardDeviation: ((Landmass)Generated).RegionDiversity);

            // Sunlight Energy Concentration
            ((Landmass)Generated).AverageSunlightConcentration = Gaussian.GetGaussianRandom(
                mean: -0.3,
                standardDeviation: ((Landmass)Generated).RegionDiversity);
        }

        private void ApplyAutumn()
        {
            ((Landmass) Generated).AverageRainfall += 0.1;
            ((Landmass) Generated).AverageTemperature -= 0.05;

            // Average Hours Of Available Sunlight
            ((Landmass)Generated).AverageHoursOfAvailableSunlight = Gaussian.GetGaussianRandomInt(
                mean: 8,
                standardDeviation: ((Landmass)Generated).RegionDiversity);

            // Sunlight Energy Concentration
            ((Landmass)Generated).AverageSunlightConcentration = Gaussian.GetGaussianRandom(
                mean: 0.1,
                standardDeviation: ((Landmass)Generated).RegionDiversity);
        }

        private void ApplySummer()
        {
            ((Landmass) Generated).AverageRainfall += 0.1;
            ((Landmass) Generated).AverageTemperature += 0.3;

            // Average Hours Of Available Sunlight
            ((Landmass)Generated).AverageHoursOfAvailableSunlight = Gaussian.GetGaussianRandomInt(
                mean: 12,
                standardDeviation: ((Landmass)Generated).RegionDiversity);

            // Sunlight Energy Concentration
            ((Landmass)Generated).AverageSunlightConcentration = Gaussian.GetGaussianRandom(
                mean: 0.5,
                standardDeviation: ((Landmass)Generated).RegionDiversity);
        }

        private void ApplySpring()
        {
            ((Landmass)Generated).AverageRainfall += 0.2;

            // Average Hours Of Available Sunlight
            ((Landmass)Generated).AverageHoursOfAvailableSunlight = Gaussian.GetGaussianRandomInt(
                mean: 9,
                standardDeviation: ((Landmass)Generated).RegionDiversity);

            // Sunlight Energy Concentration
            ((Landmass)Generated).AverageSunlightConcentration = Gaussian.GetGaussianRandom(
                mean: 0.2,
                standardDeviation: ((Landmass)Generated).RegionDiversity);
        }
    }
}
