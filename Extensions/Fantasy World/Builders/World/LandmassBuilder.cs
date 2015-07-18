using System;
using System.Collections.Generic;
using PGE.Core.Builder;
using PGE.Core.Models;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Math;
using PGE.Fantasy_World.Models.World;

namespace PGE.Fantasy_World.Builders.World
{
    public class LandmassBuilder : IBuilder<Landmass>
    {
        private int _averageHoursOfAvailableSunlight = Constants.DefaultInt;
        private int _maximumNumberOfRegions = Constants.DefaultInt;
        private List<Region> _regions = new List<Region>();
        private double _regionDiversity = Constants.DefaultDouble;
        private double _proximityToEquator = Constants.DefaultDouble;
        private string _name = Constants.DefaultString;
        private string _description = Constants.DefaultString;
        private double _continentSize = Constants.DefaultDouble;
        private double _averageTemperature = Constants.DefaultDouble;
        private double _averageSunlightConcentration = Constants.DefaultDouble;
        private double _averageSoilNitrogenContent = Constants.DefaultDouble;
        private double _averageRainfall = Constants.DefaultDouble;

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

        public Landmass Build(GeneratedModel @from, Type until = null)
        {
            var resultingLandmass = Build();

            if (from.GetType() == typeof(Planet))
            {
                resultingLandmass.ProceduralBuild(from: from, until: until);
            }
            return resultingLandmass;
        }

        public void SetRelationshipDefaults()
        {
            if (_regions == null)
            {
                _regions = new List<Region>();
            }
        }

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
    }
}
