using System;

namespace PGenCore.Models
{
    public abstract class GeneratedModel
    {
        // Master Procedural-Build. Starts the chain of generation here
        public abstract void ProceduralBuild(Type until);

        // Linked Procedural Build. Continues in the chain of generation
        public abstract void ProceduralBuild(GeneratedModel from, Type until);
    }
}
