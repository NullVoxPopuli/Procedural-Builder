using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGE.Core.Builder;
using PGE.Fantasy_World.Civilization.Macro.Objects;
using PGE.Fantasy_World.Models.World;

namespace PGE.Fantasy_World.World.Builders
{
    public class RegionBuilder : IBuilder<Region>
    {
        private double _windAmount = 0;
        private double _sunlightConcentration = 0;
        private double _stabilityOfClimate = 0;
        private double _soilNitrogenContent = 0;
        private List<Settlement> _settlements;
        private int _hoursOfAvailableSunlight = 0;
        private double _averageTemperature = 0;
        private double _averageRainfall = 0;

        public Region Build()
        {
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

        public void SetRelationshipDefaults()
        {
            if (_settlements == null)
            {
                _settlements = new List<Settlement>();
            }
        }

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
