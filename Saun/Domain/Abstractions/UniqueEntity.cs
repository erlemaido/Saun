using Data.Abstractions;

namespace Domain.Abstractions
{
    public abstract class UniqueEntity<T> : IUniqueEntity<T> where T : UniqueEntityData, new()
    {
        // Piho on muutnud struktuuri. Tal on loodud ValueObject klass, millega see seotud
        public virtual int Id { get; }

        public T Data { get; internal set; } = null!;
    }
}