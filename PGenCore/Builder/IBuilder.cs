using System;
using PGenCore.Models;

namespace PGenCore.Builder
{
    // Factory Method For whatever generic type exists
    public interface IBuilder<T>
    {
        // Generic, Non-Procedural Build
        T BuildFlat();

        // Master Procedural-Build. Starts the chain of generation here and ends at a specified point
        T Build(Type until = null);

        // Linked Procedural Build. Continus in the chain of generation
        T Build(GeneratedModel from, Type until = null);

        // Used for creating default object Relationships to prevent nulls
        void SetRelationshipDefaults();
    }
}
