using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGE.Core.Generator;
using PGE.Fantasy_World.Builders.Civilization.Civilization.Builders;
using PGE.Fantasy_World.Builders.Civilization.Civilization.Objects;
using PGE.Fantasy_World.Builders.Life;
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
            var Builder = new GenericBuildingBuilder();

            gen.Add(Builder);

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
            var Builder = new ReligiousBuildingBuilder();
            gen.Add(Builder);

            var npcGen = new Generator<Humanoid>();
            npcGen.Add(new HumanoidBuilder());
            var npc = npcGen.Build();
            Builder.SetOwner(npc);

            var building = gen.Build();

            Assert.AreEqual(npc,building.Owner);
        }

        [TestMethod]
        public void CanSetBuildingType()
        {
            var gen = new Generator<ReligiousBuilding>();
            var Builder = new ReligiousBuildingBuilder();
            gen.Add(Builder);

            const string testType = "Basic Description";
            Builder.SetType(testType);

            var building = gen.Build();

            Assert.IsTrue(building.Type.Equals(testType));
        }

        [TestMethod]
        public void CanGenerateReligious()
        {
            var gen = new Generator<ReligiousBuilding>();

            var Builder = new ReligiousBuildingBuilder();
            gen.Add(Builder);

            var building = gen.Build();

            Assert.IsNotNull(building);
            Assert.IsNotNull(building.Owner);
            Assert.IsTrue(building.GetType() == typeof(ReligiousBuilding));
        }

        [TestMethod]
        public void CanGenerateReligious_WithSetPatron()
        {
            var gen = new Generator<ReligiousBuilding>();

            var Builder = new ReligiousBuildingBuilder();
            gen.Add(Builder);

            const string testType = "Basic Patron";
            Builder.SetPatron(testType);

            var building = gen.Build();

            Assert.IsTrue(building.Patron.Equals(testType));
        }

        [TestMethod]
        public void CanGenerateResidence()
        {
            var gen = new Generator<Residence>();

            var Builder = new ResidenceBuilder();
            gen.Add(Builder);

            var building = gen.Build();

            Assert.IsNotNull(building);
            Assert.IsNotNull(building.Owner);
            Assert.IsTrue(building.GetType() == typeof(Residence));
        }

        [TestMethod]
        public void CanGenerateResidence_WithSetInhabintants()
        {
            var gen = new Generator<Residence>();

            var Builder = new ResidenceBuilder();
            gen.Add(Builder);

            var npcs = new List<Humanoid>();
            Builder.SetInhabitants(npcs);
            var building = gen.Build();

            Assert.IsTrue(building.Inhabitants.Equals(npcs));
        }

        [TestMethod]
        public void CanGenerateShop()
        {
            var gen = new Generator<Shop>();

            var Builder = new ShopBuilder();
            gen.Add(Builder);

            var building = gen.Build();

            Assert.IsNotNull(building);
            Assert.IsNotNull(building.Owner);
            Assert.IsTrue(building.GetType() == typeof(Shop));
        }

        [TestMethod]
        public void CanGenerateShop_WithSetInventory()
        {
            var gen = new Generator<Shop>();

            var Builder = new ShopBuilder();
            gen.Add(Builder);

            var inventory = new List<string>();
            Builder.SetInventory(inventory);
            var building = gen.Build();

            Assert.IsTrue(building.Inventory.Equals(inventory));
        }

        [TestMethod]
        public void CanGenerateTavern()
        {
            var gen = new Generator<Tavern>();

            var Builder = new TavernBuilder();
            gen.Add(Builder);

            var building = gen.Build();

            Assert.IsNotNull(building);
            Assert.IsNotNull(building.Owner);
            Assert.IsTrue(building.GetType() == typeof(Tavern));
        }

        [TestMethod]
        public void CanGenerateTavern_WithSetName()
        {
            var gen = new Generator<Tavern>();

            var Builder = new TavernBuilder();
            gen.Add(Builder);

            const string testName = "Test Name";
            Builder.SetName(testName);
            var building = gen.Build();

            Assert.IsTrue(building.Name.Equals(testName));
        }

        [TestMethod]
        public void CanGenerateWarehouse()
        {
            var gen = new Generator<Warehouse>();

            var Builder = new WarehouseBuilder();
            gen.Add(Builder);

            var building = gen.Build();

            Assert.IsNotNull(building);
            Assert.IsNotNull(building.Owner);
            Assert.IsTrue(building.GetType() == typeof(Warehouse));
        }

        [TestMethod]
        public void CanGenerateWarehouse_WithSetInventory()
        {
            var gen = new Generator<Warehouse>();

            var Builder = new WarehouseBuilder();
            gen.Add(Builder);

            var inventory = new List<string>();
            Builder.SetInventory(inventory);
            var building = gen.Build();

            Assert.IsTrue(building.Inventory.Equals(inventory));
        }
    }
}
