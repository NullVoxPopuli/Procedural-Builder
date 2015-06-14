using PGE.Core.Generated_Items;

namespace PGE.Core.Generator
{
    // Factory Method For whatever generic type exists
    public class Generator<T> where T : new()
    {
        // Generic type should take an Abstract Parameters Object, which is relevant to whichever
        // type it is. This is where all of the procedural generation occurs

        // Generator<Room>
        /* This should take in a RoomParameters object, which is used as a basis for procedurally
         * generating the room. The Generator<Room> simply takes the Parameters and interpolates
         * on each of the parameters
         */

        private GenerationParameters _generationParameters;

        public void Add(GenerationParameters parameters)
        {
            _generationParameters = parameters;
        }

        public T Build()
        {
            var generated = new T();

            if (_generationParameters != null)
            {
                _generationParameters.ApplyParameters(generated as AbstractGeneratableObject);
            }
            return generated;
        }
    }
}
