using System;
using PGE.Core.Models;

namespace PGE.Core.Builder
{
    // Factory Method For whatever generic type exists
    public interface IBuilder<T>
    {
        T Build();
        void SetRelationshipDefaults();
        T ProceduralBuild(GeneratedModel from, Type until = null);
    }
}
