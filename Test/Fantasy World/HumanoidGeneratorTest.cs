using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGE.Core.Generator;
using PGE.Fantasy_World.Lifeforms.Generation_Parameters;
using PGE.Fantasy_World.Lifeforms.Objects;

namespace PGE.Fantasy_World.Tests
{
    [TestClass]
    public class HumanoidGeneratorTest
    {
        [TestMethod]
        public void GenerateAlignment_ShouldResultInOneOfNineOptions()
        {
            var gen = new Generator<Humanoid>();
            var generationParams = new HumanoidBuilder();
            generationParams.SetNumberOfIdeals(3);
            generationParams.SetNumberOfNames(2);
            generationParams.SetNumberOfFlaws(2);
            generationParams.SetNumberOfMannerisms(2);

            gen.Add(generationParams);
            var npcs = new List<Humanoid>();

            for (var i = 0; i < 3; i++)
            {
                npcs.Add(gen.Build());
            }

            Assert.IsNotNull(npcs);
        }


        [TestMethod]
        public void GenerateBonds_ShouldGenerate()
        {
            var gen = new Generator<Humanoid>();

            gen.Add(new HumanoidBuilder());

            var npc = gen.Build();

            Assert.IsNotNull(npc.Bonds);
        }

        [TestMethod]
        public void GenerateName_ShouldGenerate()
        {
            var gen = new Generator<Humanoid>();

            var generationParams = new HumanoidBuilder();
            generationParams.SetNumberOfNames(2);
            gen.Add(generationParams);

            var npc = gen.Build();

            Assert.IsNotNull(npc.Name);
        }

        [TestMethod]
        public void GenerateAppearance_ShouldGenerate()
        {
            var gen = new Generator<Humanoid>();

            var generationParams = new HumanoidBuilder();
            generationParams.SetNumberOfAppearanceTraits(2);
            gen.Add(generationParams);

            var npc = gen.Build();

            Assert.IsNotNull(npc.Hair);
            Assert.IsNotNull(npc.EyeColor);
        }

        [TestMethod]
        public void GenerateTalents_ShouldGenerate()
        {
            var gen = new Generator<Humanoid>();

            var generationParams = new HumanoidBuilder();
            generationParams.SetNumberOfTalents(2);
            gen.Add(generationParams);

            var npc = gen.Build();

            Assert.IsNotNull(npc.Talents);
        }

        [TestMethod]
        public void GenerateTraits_ShouldGenerate()
        {
            var gen = new Generator<Humanoid>();

            var generationParams = new HumanoidBuilder();
            generationParams.SetNumberOfTraits(2);
            gen.Add(generationParams);

            var npc = gen.Build();

            Assert.IsNotNull(npc.InteractionTraits);
        }

        [TestMethod]
        public void GenerateMannerisms_ShouldGenerate()
        {
            var gen = new Generator<Humanoid>();

            gen.Add(new HumanoidBuilder());

            var npc = gen.Build();

            Assert.IsNotNull(npc.Mannerisms);
        }

        [TestMethod]
        public void GenerateAbilities_ShouldGenerate()
        {
            var gen = new Generator<Humanoid>();

            gen.Add(new HumanoidBuilder());

            var npc = gen.Build();

            Assert.IsNotNull(npc.HighAbility);
            Assert.IsNotNull(npc.LowAbility);

            var regex = new Regex(@"\([a-zA-Z]*\)");
            Assert.IsTrue(regex.Match(npc.HighAbility).Value != regex.Match(npc.LowAbility).Value);
        }


        [TestMethod]
        public void GenerateIdeals_ShouldResultInIdeals()
        {
            var gen = new Generator<Humanoid>();
            var generationParams = new HumanoidBuilder();
            generationParams.SetNumberOfIdeals(3);

            gen.Add(generationParams);

            var npc = gen.Build();

            Assert.IsNotNull(npc.Ideals);
        }
    }
}
