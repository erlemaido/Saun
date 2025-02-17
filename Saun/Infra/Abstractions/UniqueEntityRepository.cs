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
        protected UniqueEntityRepository(DbContext context, DbSet<TData> dbSet) : base(context, dbSet)
        {
        }

        protected override async Task<TData> GetData(string id)
        {
            return await dbSet.FirstOrDefaultAsync(m => m.Id == id);
        }

        protected override string GetId(TDomain entity) => entity.Data.Id;
        
        protected override TData GetDataById(TData data) => dbSet.Find(data.Id);
    }
}