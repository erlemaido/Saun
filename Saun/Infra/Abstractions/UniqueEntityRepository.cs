using System;
using System.Threading.Tasks;
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

        protected override async Task<TData> GetData(Guid id)
        {
            return await dbSet.FirstOrDefaultAsync(m => m.Id == id);
        }

        protected override Guid GetId(TDomain entity) => (Guid)(entity?.Data?.Id);
    }
}