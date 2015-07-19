using System;

namespace PGE.Core.Models
{
    public abstract class GeneratedModel
    {
        public String Name;
        public String Description;

        public abstract void ProceduralBuild(Type until);
        public abstract void ProceduralBuild(GeneratedModel from, Type until);
    }
}
