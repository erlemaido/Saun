using Data.Abstractions;

namespace Domain.Abstractions
{
    public abstract class DefinedEntity<TData> : NamedEntity<TData>, IDefinedEntity<TData> where TData : DefinedEntityData, new()
    {
        // ei saa sellest aru
        protected internal DefinedEntity(TData d) : base(d)
        {
            
        }

        public virtual string Description => Data.Description;
    }
}