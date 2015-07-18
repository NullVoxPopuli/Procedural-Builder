using System;
using PGE.Core.Models;

namespace PGE.Core.Builder
{
    // Factory Method For whatever generic type exists
    public interface IBuilder<T>
    {
        T Build();
        T Build(GeneratedModel from, System.Type until = null);
        void SetRelationshipDefaults();
    }
}
