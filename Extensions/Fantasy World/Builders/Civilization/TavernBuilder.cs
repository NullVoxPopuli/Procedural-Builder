using System;
using System.Collections.Generic;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Models.Civilization;

namespace PGE.Fantasy_World.Builders.Civilization
{
    public class TavernBuilder : GenericBuildingBuilder
    {
        public Tavern Build()
        {
            return new Tavern()
            {
                Name = _name,
                Owner = _owner,
                Type = _buildingType
            };
        }

        public void SetRelationshipDefaults()
        {
            base.SetRelationshipDefaults();

            if (String.IsNullOrEmpty(_buildingType))
            {
                GenerateType();
            }
            if (String.IsNullOrEmpty(_name))
            {
                GenerateType();
            }
        }

        protected void GenerateType()
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
            
            _buildingType = Dice.RollOnTable(tavernTypeTable);
        }

        protected void GenerateName()
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

            _name = Dice.RollOnTable(firstNamePartTable) + " " + Dice.RollOnTable(secondNamePartTable); 
        }
    }
}
