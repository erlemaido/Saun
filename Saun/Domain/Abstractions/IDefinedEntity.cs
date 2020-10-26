namespace Domain.Abstractions
{
    public interface IDefinedEntity : INamedEntity
    {
        string? Description { get; }
    }

    public interface IDefinedEntity<out TData> : IDefinedEntity, IUniqueEntity<TData>
    {
        
    }
}