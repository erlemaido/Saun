namespace Domain.Abstractions
{
    public interface IUniqueEntity
    {
        int Id { get; }
    }

    public interface IUniqueEntity<out TData> : IUniqueEntity
    {
        TData Data { get; }
    }
}