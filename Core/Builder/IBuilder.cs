using System;
using PGE.Core.Models;

namespace PGE.Core.Builder
{
    // Factory Method For whatever generic type exists
    public interface IBuilder<T>
    {
        // Generic, Non-Procedural Build
        T Build();

        // Master Procedural-Build. Starts the chain of generation here
        T Build(Type until);

        // Linked Procedural Build. Continus in the chain of generation
        T Build(GeneratedModel from, Type until = null);

        // Used for creating default object Relationships to prevent nulls
        void SetRelationshipDefaults();
    }
}
