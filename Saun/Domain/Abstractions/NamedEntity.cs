using Data.Abstractions;

namespace Domain.Abstractions
{
    public abstract class NamedEntity<TData> : UniqueEntity<TData> where TData : NamedEntityData, new()
    {
        // ei saa sellest aru
        protected internal NamedEntity(TData data) : base(data)
        {
            
        }

        public virtual string Name => Data.Name;
    }
}