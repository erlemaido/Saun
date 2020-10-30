using Data.Abstractions;
using Domain.Abstractions;

namespace Infra.Abstractions
{
    public abstract class UniqueEntityRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        
    }
}