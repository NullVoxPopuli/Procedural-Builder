using System;
using System.Collections.Generic;
using PGE.Core.Builder;
using PGE.Core.Models;
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

        // Generic, Non-Procedural Build
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

        // Master Procedural-Build. Starts the chain of generation here
        public Region Build(Type until)
        {
            var region = Build();
            region.ProceduralBuild(until);

            return region;
        }

        // Linked Procedural Build. Continus in the chain of generation
        public Region Build(GeneratedModel @from, Type until = null)
        {
            var resultingRegion = Build();

            if (from.GetType() == typeof(Landmass))
            {
                resultingRegion.ProceduralBuild(from: from, until: until);
            }
            return resultingRegion;
        }

        // Used for creating default object Relationships to prevent nulls
        public void SetRelationshipDefaults()
        {
            if (_settlements == null)
            {
                _settlements = new List<Settlement>();
            }
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
