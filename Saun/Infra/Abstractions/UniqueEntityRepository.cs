using Data.Abstractions;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Abstractions
{
    public abstract class UniqueEntityRepository<TDomain, TData> : PaginatedRepository<TDomain, TData>
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        protected UniqueEntityRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
        }
    }
}