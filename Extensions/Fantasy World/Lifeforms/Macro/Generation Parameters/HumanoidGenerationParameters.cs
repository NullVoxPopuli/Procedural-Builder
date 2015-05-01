using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using PGE.Core.Generated_Items;
using PGE.Core.Statistics;
using PGE.Fantasy_World.Lifeforms.Objects;

namespace PGE.Fantasy_World.Lifeforms.Generation_Parameters
{
    public class HumanoidGenerationParameters : GenerationParameters
    {
        private int _numberOfIdeals = 1,
            _numberOfBonds = 1,
            _numberOfAppearanceTraits = 1,
            _numberOfMannerisms = 1,
            _numberOfNames = 1,
            _numberOfTalents = 1,
            _numberOfTraits = 1,
            _numberOfFlaws = 1;

        #region Setters
        public void SetNumberOfIdeals(int num)
        {
            _numberOfIdeals = num;
        }

        public void SetNumberOfBonds(int num)
        {
            _numberOfBonds = num;
        }

        public void SetNumberOfAppearanceTraits(int num)
        {
            _numberOfAppearanceTraits = num;
        }

        public void SetNumberOfMannerisms(int num)
        {
            _numberOfMannerisms = num;
        }

        public void SetNumberOfNames(int num)
        {
            _numberOfNames = num;
        }

        public void SetNumberOfTalents(int num)
        {
            _numberOfTalents = num;
        }

        public void SetNumberOfTraits(int num)
        {
            _numberOfTraits = num;
        }

        public void SetNumberOfFlaws(int num)
        {
            _numberOfFlaws = num;
        }
        #endregion

        public override void ApplyParameters(IGeneratable gen)
        {
            Generated = gen;

            GenerateName();
            GenerateAlignmentAndIdeals();
            GenerateAppearance();
            GenerateAbilities();
            GenerateTalents();
            GenerateMannerisms();
            GenerateInteractionTraits();
            GenerateBonds();
            GenerateFlawsAndSecrets();
        }

        private void GenerateName()
        {
            var firstTable = new List<string>()
            {
                "","","","",
                "a","be","de","el",
                "fa","jo","ki","la",
                "ma","na","o","pa",
                "re","si","ta","va"
            };

            var secondTable = new List<string>()
            {
                "bar","ched","dell","far",
                "gran","hal","jen","kel",
                "lim","mor","net","penn",
                "quil","rond","sark","shen",
                "tur","vash","yor","zen"
            };

            var thirdTable = new List<string>()
            {
                "","a","ac","ai",
                "al","am","an","ar",
                "ea","el","er","ess",
                "ett","ic","id","il",
                "in","is","or","us"
            };

            var names = new List<string>();
            for (var i = 0; i < _numberOfNames; i++)
            {
                var name = Dice.RollOnTable(firstTable) + Dice.RollOnTable(secondTable) + Dice.RollOnTable(thirdTable);

                if (!names.Contains(name))
                {
                    names.Add(name.First().ToString().ToUpper() + name.Substring(1));
                }
            }

            ((Humanoid)Generated).Name = string.Join(" ", names);
        }

        private void GenerateAlignmentAndIdeals()
        {
            var alignmentTable = new List<string>()
            {
                "Lawful Good", "Neutral Good", "Chaotic Good",
                "Lawful Neutral", "True Neutral", "Chaotic Neutral",
                "Lawful Evil", "Neutral Evil", "Chaotic Evil"
            };

            var alignment = Dice.RollOnTable(alignmentTable);

            #region Populate Ideals table based on alignment
            var idealsTable = new List<string>()
            {
                "Aspiration",
                "Discovery",
                "Glory",
                "Nation",
                "Redemption",
                "Self-Knowledge"
            };

            if (alignment.Contains("Good"))
            {
                idealsTable.AddRange(new List<string>
                {
                    "Beauty", "Charity", "Greater Good", "Life","Respect","Self-Sacrifice"
                });
            }
            else if (alignment.Contains("Evil"))
            {
                idealsTable.AddRange(new List<string>
                {
                    "Domination", "Greed", "Might", "Pain","Retribution","Slaughter"
                });
            }
            else if (alignment.Contains("Neutral"))
            {
                idealsTable.AddRange(new List<string>
                {
                    "Balance", "Knowledge", "Live and let live", "Moderation","Neutrality","People"
                });
            }

            if (alignment.Contains("Lawful"))
            {
                idealsTable.AddRange(new List<string>
                {
                    "Community", "Fairness", "Honor", "Logic","Responsibility","Tradition"
                });
            }
            else if (alignment.Contains("Chaotic"))
            {
                idealsTable.AddRange(new List<string>
                {
                    "Change","Creativity", "Freedom", "Independence","No Limits","Whimsy"
                });
            }
            #endregion

            var ideals = new List<string>();
            for (var i = 0; i < _numberOfIdeals; i++)
            {
                var ideal = Dice.RollOnTable(idealsTable);

                if (!ideals.Contains(ideal))
                {
                    ideals.Add(ideal);
                }
            }

            ((Humanoid)Generated).Ideals = string.Join(", ", ideals);
            ((Humanoid)Generated).Alignment = alignment;
        }

        private void GenerateAppearance()
        {
            var appearanceTable = new List<string>()
            {
                "Distinctive jewelry, earrings, necklace, circlet, bracelets",
                "Piercings",
                "Flamboyant or outlandish clothes",
                "Formal, clean clothes",
                "Ragged, dirty clothes",
                "Pronounced scar",
                "Missing teeth",
                "Missing fingers",
                "Unusual eye color",
                "Tattoos",
                "Birthmark",
                "Unusual skin color",
                "Bald",
                "Braided beard or hair",
                "Unusual beard or hair color",
                "Nervous eye twitch",
                "Distinctive nose",
                "Distinctive posture",
                "Exceptionally beautiful",
                "Exceptionally ugly"
            };

            var appearances = new List<string>();
            for (var i = 0; i < _numberOfAppearanceTraits; i++)
            {
                var appearance = Dice.RollOnTable(appearanceTable);

                if (!appearances.Contains(appearance))
                {
                    appearances.Add(appearance);
                }
            }

            ((Humanoid)Generated).Appearance = string.Join(", ", appearances);
        }

        private void GenerateAbilities()
        {
            var highAbilitiesTable = new List<string>()
            {
                "Powerful (Strength)",
                "Brawny (Strength)",
                "Strong as an ox (Stength)",
                "Lithe (Dexterity)",
                "Agile (Dexterity)",
                "Graceful (Dexterity)",
                "Hardy (Constitution)",
                "Hale (Constitution)",
                "Healthy (Constitution)",
                "Studious (Intelligence)",
                "Learned (Intelligence)",
                "Inquisitive (Intelligence)",
                "Perceptive (Wisdom)",
                "Spiritual (Wisdom)",
                "Insightful (Wisdom)",
                "Persuasive (Charisma)",
                "Forceful (Charisma)",
                "Born leader (Charisma)"
            };
            var lowAbilitiesTable = new List<string>()
            {
                "Feeble (Strength)",
                "Scrawny (Strength)",
                "Clumsy (Dexterity)",
                "Fumbling (Dexterity)",
                "Sickly (Constitution)",
                "Pale (Constitution)",
                "Dim-witted (Intelligence)",
                "Slow (Intelligence)",
                "Oblivious (Wisdom)",
                "Absent-minded (Wisdom)",
                "Dull (Charisma)",
                "Boring (Charisma)"
            };

            var highAbility = Dice.RollOnTable(highAbilitiesTable);

            var regex = new Regex(@"\([a-zA-Z]*\)");
            var highAbilityType = regex.Match(highAbility).Value;
            string lowAbility;

            do
            {
                lowAbility = Dice.RollOnTable(lowAbilitiesTable);
            }
            while (lowAbility.Contains(highAbilityType));

            ((Humanoid)Generated).HighAbility = highAbility;
            ((Humanoid)Generated).LowAbility = lowAbility;
        }

        private void GenerateTalents()
        {
            var talentsTable = new List<string>()
            {
                "Plays a musical instrument",
                "Speaks several languages fluently",
                "Unbelievably lucky",
                "Perfect memory",
                "Great with animals",
                "Great with children",
                "Great at solving puzzles and riddles",
                "Great at a game",
                "Great at impersonations",
                "Draws beautifully",
                "Paints beautifully",
                "Sings beautifully",
                "Drinks everyone under the table",
                "Expert carpenter",
                "Expert cook",
                "Expert dart thrower and rock skipper",
                "Expert juggler",
                "Skilled actor or master of disguise",
                "Skilled dancer",
                "Knows thieves' cant"
            };
            var talents = new List<string>();
            for (var i = 0; i < _numberOfTalents; i++)
            {
                var talent = Dice.RollOnTable(talentsTable);

                if (!talents.Contains(talent))
                {
                    talents.Add(talent);
                }
            }

            ((Humanoid)Generated).Talents = string.Join(", ", talents);
        }

        private void GenerateMannerisms()
        {
            var mannerismsTable = new List<string>()
            {
                "Prone to singing, whistling, or humming quietely",
                "Speaks in rhyme or some other peculiar way",
                "Particularly low voice",
                "Particularly high voice",
                "Slurs words, lisps, or stutters",
                "Enunciates overly clearly",
                "Speaks loudly",
                "Whispers",
                "Uses flowery speech or long words",
                "Frequently uses the wrong word",
                "Uses colorful oaths and exclamations",
                "Makes constant jokes or puns",
                "Prone to predictions of doom",
                "Fidgets",
                "Squints",
                "Stares into the distance",
                "Chews something",
                "Paces",
                "Taps fingers",
                "Bites fingernails",
                "Twirls hair or tugs beard"
            };

            var mannerisms = new List<string>();
            for (var i = 0; i < _numberOfMannerisms; i++)
            {
                var mannerism = Dice.RollOnTable(mannerismsTable);

                if (!mannerisms.Contains(mannerism))
                {
                    mannerisms.Add(mannerism);
                }
            }

            ((Humanoid)Generated).Mannerisms = string.Join(", ", mannerisms);
        }

        private void GenerateInteractionTraits()
        {
            var traitsTable = new List<string>()
            {
                "Argumentative",
                "Arrogant",
                "Blustering",
                "Rude",
                "Curious",
                "Friendly",
                "Honest",
                "Hot Tempered",
                "Irritable",
                "Ponderous",
                "Quiet",
                "Suspicious"
            };
            var traits = new List<string>();
            for (var i = 0; i < _numberOfTraits; i++)
            {
                var trait = Dice.RollOnTable(traitsTable);

                if (!traits.Contains(trait))
                {
                    traits.Add(trait);
                }
            }

            ((Humanoid)Generated).InteractionTraits = string.Join(", ", traits);
        }

        private void GenerateBonds()
        {
            var bondsTable = new List<string>()
            {
                "Dedicated to fulfilling a personal life goal",
                "Protective of close family members",
                "Protective of colleagues or compatriots",
                "Loyal to a benefactor, patron, or employer",
                "Captivated by a romantic interest",
                "Drawn to a special place",
                "Protective of a sentimental keepsake",
                "Protective of a valuable possession",
                "Out for revenge"
            };
            var bonds = new List<string>();
            for (var i = 0; i < _numberOfBonds; i++)
            {
                var bond = Dice.RollOnTable(bondsTable);

                if (!bonds.Contains(bond))
                {
                    bonds.Add(bond);
                }
            }

            ((Humanoid)Generated).Bonds = string.Join(", ", bonds);
        }

        private void GenerateFlawsAndSecrets()
        {
            var flawsTable = new List<string>()
            {
                "Forbidden love",
                "Susceptibility to romance",
                "Enjoys decadent pleasures",
                "Arrogance",
                "Envies another's possesions",
                "Envies another's station",
                "Avarice",
                "Prone to rage",
                "Has a powerful enemy",
                "Acrophobia",
                "Claustrophobia",
                "Other phobia",
                "Shameful or scandalous history",
                "Secret crime or misdeed",
                "Possesses forbidden lore",
                "Foolhardy bravery"
            };
            var flaws = new List<string>();
            for (var i = 0; i < _numberOfFlaws; i++)
            {
                var flaw = Dice.RollOnTable(flawsTable);

                if (!flaws.Contains(flaw))
                {
                    flaws.Add(flaw);
                }
            }

            ((Humanoid)Generated).FlawOrSecret = string.Join(", ", flaws);
        }
    }
}
