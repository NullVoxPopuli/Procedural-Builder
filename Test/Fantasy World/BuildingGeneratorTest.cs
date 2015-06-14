using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGE.Core.Generator;
using PGE.Fantasy_World.Civilization.Buildings.Generation_Parameters;
using PGE.Fantasy_World.Civilization.Buildings.Objects;
using PGE.Fantasy_World.Lifeforms.Generation_Parameters;
using PGE.Fantasy_World.Lifeforms.Objects;

namespace PGE.Fantasy_World.Tests
{
    [TestClass]
    public class BuildingGeneratorTest
    {
        [TestMethod]
        public void CanGenerateMany()
        {
            var gen = new Generator<Building>();
            var generationParameters = new GenericBuildingGenerationParameters();

            gen.Add(generationParameters);

            var buildings = new List<Building>();

            for (var i = 0; i < 30; i++)
            {
                buildings.Add(gen.Build());
            }

            Assert.IsNotNull(buildings);
        }

        [TestMethod]
        public void CanSetOwner()
        {
            var gen = new Generator<ReligiousBuilding>();
            var generationParameters = new ReligiousBuildingGenerationParameters();
            gen.Add(generationParameters);

            var npcGen = new Generator<Humanoid>();
            npcGen.Add(new HumanoidGenerationParameters());
            var npc = npcGen.Build();
            generationParameters.SetOwner(npc);

            var building = gen.Build();

            Assert.AreEqual(npc,building.Owner);
        }

        [TestMethod]
        public void CanSetBuildingType()
        {
            var gen = new Generator<ReligiousBuilding>();
            var generationParameters = new ReligiousBuildingGenerationParameters();
            gen.Add(generationParameters);

            const string testType = "Basic Description";
            generationParameters.SetType(testType);

            var building = gen.Build();

            Assert.IsTrue(building.Type.Equals(testType));
        }

        [TestMethod]
        public void CanGenerateReligious()
        {
            var gen = new Generator<ReligiousBuilding>();

            var generationParameters = new ReligiousBuildingGenerationParameters();
            gen.Add(generationParameters);

            var building = gen.Build();

            Assert.IsNotNull(building);
            Assert.IsNotNull(building.Owner);
            Assert.IsTrue(building.GetType() == typeof(ReligiousBuilding));
        }

        [TestMethod]
        public void CanGenerateReligious_WithSetPatron()
        {
            var gen = new Generator<ReligiousBuilding>();

            var generationParameters = new ReligiousBuildingGenerationParameters();
            gen.Add(generationParameters);

            const string testType = "Basic Patron";
            generationParameters.SetPatron(testType);

            var building = gen.Build();

            Assert.IsTrue(building.Patron.Equals(testType));
        }

        [TestMethod]
        public void CanGenerateResidence()
        {
            var gen = new Generator<Residence>();

            var generationParameters = new ResidenceGenerationParameters();
            gen.Add(generationParameters);

            var building = gen.Build();

            Assert.IsNotNull(building);
            Assert.IsNotNull(building.Owner);
            Assert.IsTrue(building.GetType() == typeof(Residence));
        }

        [TestMethod]
        public void CanGenerateResidence_WithSetInhabintants()
        {
            var gen = new Generator<Residence>();

            var generationParameters = new ResidenceGenerationParameters();
            gen.Add(generationParameters);

            var npcs = new List<Humanoid>();
            generationParameters.SetInhabitants(npcs);
            var building = gen.Build();

            Assert.IsTrue(building.Inhabitants.Equals(npcs));
        }

        [TestMethod]
        public void CanGenerateShop()
        {
            var gen = new Generator<Shop>();

            var generationParameters = new ShopGenerationParameters();
            gen.Add(generationParameters);

            var building = gen.Build();

            Assert.IsNotNull(building);
            Assert.IsNotNull(building.Owner);
            Assert.IsTrue(building.GetType() == typeof(Shop));
        }

        [TestMethod]
        public void CanGenerateShop_WithSetInventory()
        {
            var gen = new Generator<Shop>();

            var generationParameters = new ShopGenerationParameters();
            gen.Add(generationParameters);

            var inventory = new List<string>();
            generationParameters.SetInventory(inventory);
            var building = gen.Build();

            Assert.IsTrue(building.Inventory.Equals(inventory));
        }

        [TestMethod]
        public void CanGenerateTavern()
        {
            var gen = new Generator<Tavern>();

            var generationParameters = new TavernGenerationParameters();
            gen.Add(generationParameters);

            var building = gen.Build();

            Assert.IsNotNull(building);
            Assert.IsNotNull(building.Owner);
            Assert.IsTrue(building.GetType() == typeof(Tavern));
        }

        [TestMethod]
        public void CanGenerateTavern_WithSetName()
        {
            var gen = new Generator<Tavern>();

            var generationParameters = new TavernGenerationParameters();
            gen.Add(generationParameters);

            const string testName = "Test Name";
            generationParameters.SetName(testName);
            var building = gen.Build();

            Assert.IsTrue(building.Name.Equals(testName));
        }

        [TestMethod]
        public void CanGenerateWarehouse()
        {
            var gen = new Generator<Warehouse>();

            var generationParameters = new WarehouseGenerationParameters();
            gen.Add(generationParameters);

            var building = gen.Build();

            Assert.IsNotNull(building);
            Assert.IsNotNull(building.Owner);
            Assert.IsTrue(building.GetType() == typeof(Warehouse));
        }

        [TestMethod]
        public void CanGenerateWarehouse_WithSetInventory()
        {
            var gen = new Generator<Warehouse>();

            var generationParameters = new WarehouseGenerationParameters();
            gen.Add(generationParameters);

            var inventory = new List<string>();
            generationParameters.SetInventory(inventory);
            var building = gen.Build();

            Assert.IsTrue(building.Inventory.Equals(inventory));
        }
    }
}
