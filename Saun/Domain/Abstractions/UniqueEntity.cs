using Data.Abstractions;

namespace Domain.Abstractions
{
    public abstract class UniqueEntity<TData> : IUniqueEntity<TData> where TData : UniqueEntityData, new()
    {
        // Piho on muutnud struktuuri. Tal on loodud ValueObject klass, millega see seotud
        public virtual string Id => Data.Id;

        public TData Data { get; }

        protected internal UniqueEntity(TData data) => Data = data;
    }
}