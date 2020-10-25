using Data.Abstractions;

namespace Domain.Abstractions
{
    public abstract class NamedEntity<T> : IUniqueEntity<T> where T : NamedEntityData, new()
    {
        public virtual string Name { get; } = null!;
    }
}