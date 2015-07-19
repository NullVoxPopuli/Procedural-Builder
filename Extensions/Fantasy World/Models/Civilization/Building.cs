using System;
using PGE.Core.Models;
using PGE.Fantasy_World.Models.Life;

namespace PGE.Fantasy_World.Models.Civilization
{
    public class Building : GeneratedModel
    {
        public string Name;
        public string Type;
        public Humanoid Owner;

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
