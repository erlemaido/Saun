namespace Saun.Domain.Abstractions
{
    public interface INamedEntity : IUniqueEntity
    {
        string Name { get; }
    }

    public interface INamedEntity<out TData> : INamedEntity, IUniqueEntity<TData>
    {
        
    }
}