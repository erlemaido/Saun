namespace Domain.Abstractions
{
    public interface IDefinedEntity : INamedEntity
    {
        string Definition { get; }
    }

    public interface IDefinedEntity<out TData> : IDefinedEntity, IUniqueEntity<TData>
    {
        
    }
}