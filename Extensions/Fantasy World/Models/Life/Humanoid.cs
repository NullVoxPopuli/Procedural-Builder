using System;
using System.Collections.Generic;
using PGE.Core.Models;
using PGE.Fantasy_World.Builders.Life;

namespace PGE.Fantasy_World.Models.Life
{
    // Essentially treated like a boolean for ease of development.
    // Sexuality identification is acknowledged but beyond the scope of this project.
    public enum Sex { Male, Female }

    public class Humanoid : GeneratedModel
    {
        public Sex Sex;

        // Master Attributes
        public double Strength;
        public double Constitution;
        public double Intelligence;
        public double Charisma;

        // Used for fitness
        public double Fertility;
        public Humanoid Mate;
        public int Age;

        // When the following reach zero, the Humanoid dies. Constitution raises each maximum value.
        public double Health;
        public double Water;
        public double Food;

        public Humanoid ProduceOffspring()
        {
            if (Mate == null || Sex == Sex.Male)
            {
                // Cannot make offspring without a mate, nor birth as a male
                return null;
            }

            // baby is null because if the parents fail to pass their fertility checks, the baby cannot be born
            Humanoid baby = null;

            // Do a fertility check for both partners
            if (PerformFertilityCheck() && Mate.PerformFertilityCheck())
            {
                // Do stuff with traits

                baby = new HumanoidBuilder().Build();
            }

            return baby;
        }

        public bool PerformFertilityCheck()
        {
            // How do we handle this?
            return true;
        }
        // Master Procedural-Build. Starts the chain of generation here
        public override void ProceduralBuild(Type until)
        {
            throw new NotImplementedException();
        }

        // Linked Procedural Build. Continues in the chain of generation
        public override void ProceduralBuild(GeneratedModel @from, Type until)
        {
            throw new NotImplementedException();
        }
    }
}
