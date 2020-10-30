using Data.Abstractions;
using Domain.Abstractions;

namespace Infra.Abstractions
{
    public abstract class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, IFiltering
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        public string? SearchString { get; set; }
        public string? CurrentFilter { get; set; }
        public string? FixedFilter { get; set; }
        public string? FixedValue { get; set; }
    }
}