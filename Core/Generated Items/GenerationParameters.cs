namespace PGE.Core.Generated_Items
{
    public abstract class GenerationParameters
    {
        protected AbstractGeneratableObject Generated;

        public virtual void ApplyParameters(AbstractGeneratableObject gen)
        {
            Generated = gen;
        }
    }
}
