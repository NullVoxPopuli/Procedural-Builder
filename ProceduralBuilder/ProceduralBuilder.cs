using System;

namespace PGenCore
{
    // Factory Method For whatever generic type exists
    public abstract class ProceduralBuilder<T> where T : GeneratedModel, new()
    {
        private GeneratedModel _from;
        private System.Type _until;
        private bool _flat;

        // Generic, Non-Procedural Build
        public T Build()
        {
            SetRelationshipDefaults();
            var output = BuildInitialModel();

            if (!_flat)
            {
                output.ProceduralBuild(_from, _until);
            }

            return output;
        }

        protected virtual T BuildInitialModel()
        {
            return new T();
        }

        public ProceduralBuilder<T> Until(Type until = null)
        {
            _until = until;
            return this;
        }

        public ProceduralBuilder<T> Using(GeneratedModel from)
        {
            _from = from;
            return this;
        }

        public ProceduralBuilder<T> Flat(bool flat = true)
        {
            _flat = flat;
            return this;
        }

        // Used for creating default object Relationships to prevent nulls
        protected abstract void SetRelationshipDefaults();
    }
}
