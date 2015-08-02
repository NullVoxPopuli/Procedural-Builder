using System;
using PGenCore.Models;

namespace PGenCore.Builder
{
    // Factory Method For whatever generic type exists
    public abstract class ProceduralBuilder<T>
    {
        protected GeneratedModel _from;
        protected System.Type _until;

        // Generic, Non-Procedural Build
        public abstract T Build();

        // Master Procedural-Build. Starts the chain of generation here and ends at a specified point
        public ProceduralBuilder<T> Until(Type until = null)
        {
            _until = until;
            return this;
        }

        // Linked Procedural Build. Continus in the chain of generation
        public ProceduralBuilder<T> Using(GeneratedModel from)
        {
            _from = from;
            return this;
        }

        // Used for creating default object Relationships to prevent nulls
        public abstract void SetRelationshipDefaults();
    }
}
