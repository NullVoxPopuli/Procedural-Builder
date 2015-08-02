using System;
using PGenCore.Models;

namespace PGenCore.Builder
{
    // Factory Method For whatever generic type exists
    public abstract class ProceduralBuilder<T> where T : GeneratedModel, new()
    {
        private GeneratedModel _from;
        private System.Type _until;
        private bool _single;

        // Generic, Non-Procedural Build
        public T Build()
        {
            SetRelationshipDefaults();
            var output = BuildFlat();

            if (!_single)
            {
                output.ProceduralBuild(_from, _until);
            }

            return output;
        }

        public virtual T BuildFlat()
        {
            return new T();
        }

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

        public ProceduralBuilder<T> Single(bool flat = true)
        {
            _single = flat;
            return this;
        }

        // Used for creating default object Relationships to prevent nulls
        public abstract void SetRelationshipDefaults();
    }
}
