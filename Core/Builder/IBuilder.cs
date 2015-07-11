using System;
using PGE.Core.Models;

namespace PGE.Core.Builder
{
    // Factory Method For whatever generic type exists
    public interface IBuilder<T>
    {
        T Build();
        void SetRelationshipDefaults();
        T ProceduralBuild(Model from, Type until = null);
    }
}
