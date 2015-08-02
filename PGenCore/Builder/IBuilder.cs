using System;
using PGenCore.Models;

namespace PGenCore.Builder
{
    // Factory Method For whatever generic type exists
    public interface IBuilder<T>
    {
        // Generic, Non-Procedural Build
        T Build();

        // Master Procedural-Build. Starts the chain of generation here and ends at a specified point
        IBuilder<T> Until(Type until = null);

        // Linked Procedural Build. Continus in the chain of generation
        IBuilder<T> Using(GeneratedModel from);

        // Used for creating default object Relationships to prevent nulls
        void SetRelationshipDefaults();
    }
}
