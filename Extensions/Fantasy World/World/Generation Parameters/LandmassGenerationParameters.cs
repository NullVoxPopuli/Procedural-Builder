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

        public void CalculateAverages(Objects.World.Season currentSeason, double globalTemperature, double globalRainfall)
        {
            // Hardcoded for now, should be specified by the World
            var regionDiversity = Gaussian.GetGaussianRandom(
                mean: 0.5, 
                standardDeviation: 0.1);

            // Average Rainfall
            ((Landmass)Generated).AverageRainfall = Gaussian.GetGaussianRandom(
                mean: globalRainfall,
                standardDeviation: regionDiversity);

            // Average Temperature
            ((Landmass)Generated).AverageTemperature = Gaussian.GetGaussianRandom(
                mean: globalTemperature,
                standardDeviation: regionDiversity);

            ApplySeasonToAverages(currentSeason);
        }

        private void ApplySeasonToAverages(Objects.World.Season currentSeason)
        {
            switch (currentSeason)
            {
                case Objects.World.Season.Spring:
                    ((Landmass) Generated).AverageRainfall += 0.2;
                    break;
                case Objects.World.Season.Summer:
                    ((Landmass) Generated).AverageRainfall += 0.1;
                    ((Landmass) Generated).AverageTemperature += 0.3;
                    break;
                case Objects.World.Season.Autumn:
                    ((Landmass) Generated).AverageRainfall += 0.1;
                    ((Landmass) Generated).AverageTemperature -= 0.05;
                    break;
                case Objects.World.Season.Winter:
                    ((Landmass) Generated).AverageRainfall -= 0.1;
                    ((Landmass) Generated).AverageTemperature -= 0.4;
                    break;
            }
        }
    }
}
