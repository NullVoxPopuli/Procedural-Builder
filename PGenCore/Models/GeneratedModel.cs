using System;

namespace PGenCore.Models
{
    public abstract class GeneratedModel
    {
        // Linked Procedural Build. Continues in the chain of generation
        public abstract void ProceduralBuild(GeneratedModel from, Type until);
    }
}
