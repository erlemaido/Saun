using Data.Abstractions;
using Domain.Abstractions;

namespace Infra.Abstractions
{
    public abstract class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        public string? SortOrder { get; set; }
    }
}