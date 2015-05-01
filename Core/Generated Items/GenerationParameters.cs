namespace PGE.Core.Generated_Items
{
    public abstract class GenerationParameters
    {
        protected IGeneratable Generated;

        public virtual void ApplyParameters(IGeneratable gen)
        {
            Generated = gen;
        }
    }
}
