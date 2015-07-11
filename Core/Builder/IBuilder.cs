using PGE.Core.Models;

namespace PGE.Core.Builder
{
    // Factory Method For whatever generic type exists
    public interface IBuilder<T>
    {
        T Build();
        void SetRelationshipDefaults();
        void DoProceduralGeneration(Model model);
    }
}
