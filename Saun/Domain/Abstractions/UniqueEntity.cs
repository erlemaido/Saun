using Data.Abstractions;

namespace Domain.Abstractions
{
    public abstract class UniqueEntity<TData> : IUniqueEntity<TData> where TData : UniqueEntityData, new()
    {
        public virtual string Id => Data?.Id;

        public TData Data { get; }

        protected internal UniqueEntity(TData data) => Data = data;
    }
}