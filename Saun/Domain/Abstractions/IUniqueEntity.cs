
namespace Domain.Abstractions
{
    public interface IUniqueEntity
    {
        string Id { get; }
    }

    public interface IUniqueEntity<out TData> : IUniqueEntity
    {
        TData Data { get; }
    }
}