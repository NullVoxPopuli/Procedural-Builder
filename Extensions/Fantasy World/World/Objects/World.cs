using System.Collections.Generic;
using PGE.Core.Generated_Items;

namespace PGE.Fantasy_World.World.Objects
{
    public class World : AbstractGeneratableObject
    {
        public List<Landmass> Continents;

        // Procedural Generation parameters should include anything that discusses the planet as a whole. For instance...

        // How close is it to the sun? 
        // -1.0 being closer than normal (like Venus) 
        // 0.0 being completely even with Earth's orbit
        // 1.0 being further than normal (like Mars)
        public double ProximityToSolarEntity = 0.0;
        
        // What season is it?
        public enum Season
        {
            Winter, Spring, Summer, Autumn
        };
        public Season CurrentSeason;

        // Does the planet have a predisposition to warmer climates?
        // -1.0 Much colder than normal
        // 0.0 even with Earth
        // 1.0 Much warmer than normal
        public double RelativeTemperature;

        // How do the continents connect?
        // -1.0 being completely together, like Pangea
        // 0.0 being where we are with the continents now on Earth
        // 1.0 being spread apart with each continent as its own island
        public double ContinentSpread;
    }
}
