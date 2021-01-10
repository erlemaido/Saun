using Data.Abstractions;

namespace Domain.Abstractions
{
    public abstract class DefinedEntity<TData> : NamedEntity<TData>, IDefinedEntity<TData> where TData : DefinedEntityData, new()
    {
        protected internal DefinedEntity(TData data) : base(data)
        {
            
        }

        public virtual string Description => Data.Description;
    }
}