using Saun.Data.Abstractions;

namespace Saun.Domain.Abstractions
{
    public abstract class NamedEntity<TData> : UniqueEntity<TData> where TData : NamedEntityData, new()
    {
        // ei saa sellest aru
        protected internal NamedEntity(TData d = null!) : base(d)
        {
            
        }

        public virtual string Name => Data.Name;
    }
}