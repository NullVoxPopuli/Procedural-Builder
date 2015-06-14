using System.Collections.Generic;
using PGE.Core.Generated_Items;
using PGE.Core.Statistics;

namespace PGE.Fantasy_World.Civilization.Buildings.Generation_Parameters
{
    public class TavernGenerationParameters : GenericBuildingGenerationParameters
    {
        public override void ApplyParameters(AbstractGeneratableObject gen)
        {
            base.ApplyParameters(gen);
        }

        #region Handle Type

        protected override void GenerateType()
        {
            var tavernTypeTable = new List<string>()
            {
                "Quiet, Low-Key Bar","Quiet, Low-Key Bar","Quiet, Low-Key Bar","Quiet, Low-Key Bar","Quiet, Low-Key Bar",
                "Raucous Dive","Raucous Dive","Raucous Dive","Raucous Dive",
                "Thieves' Guild Hideout",
                "Gathering place for a secret society",
                "Upper-class dining club","Upper-class dining club",
                "Gambling den","Gambling den",
                "Caters only to specific race","Caters only to specific race",
                "Members-only club",
                "Brothel"
            };
            
            BuildingType = Dice.RollOnTable(tavernTypeTable);
        }

        #endregion
        #region Handle Name

        protected override void GenerateName()
        {
            var firstNamePartTable = new List<string>()
            {
                "The Silver","The Golden",
                "The Staggering","The Laughing",
                "The Prancing","The Gilded",
                "The Running","The Howling",
                "The Slaughtered","The Leering",
                "The Drunken","The Leaping",
                "The Roaring","The Frowning",
                "The Lonely","The Wandering",
                "The Mysterious","The Barking",
                "The Black","The Gleaming"
            };

            var secondNamePartTable = new List<string>()
            {
                "Eel","Dolphin","Dwarf","Pegasus",
                "Pony","Rose","Stag","Wolf",
                "Lamb","Demon","Goat","Spirit",
                "Horde","Jester","Mountain","Eagle",
                "Satyr","Dog","Spider","Star"

            };

            Name = Dice.RollOnTable(firstNamePartTable) + " " + Dice.RollOnTable(secondNamePartTable); 
        }

        #endregion
    }
}
