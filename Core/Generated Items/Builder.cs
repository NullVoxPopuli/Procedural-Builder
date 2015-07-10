namespace PGE.Core.Generated_Items
{
    public abstract class Builder
    {
        protected AbstractGeneratableObject Generated;

        public virtual void ApplyParameters(AbstractGeneratableObject gen)
        {
            Generated = gen;
        }
    }
}
