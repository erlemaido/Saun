using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids.Methods;
using Data.Abstractions;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Abstractions
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>, IRepository
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        protected internal DbContext DbContext;
        protected internal DbSet<TData> DbSet;

        protected BaseRepository(DbContext context, DbSet<TData> dbSet)
        {
            DbContext = context;
            DbSet = dbSet;
        }
        protected abstract Task<TData> GetData(string id);
        protected abstract string GetId(TDomain entity);
        internal List<TDomain> ToDomainObjectsList(List<TData> set) => set.Select(ToDomainObject).ToList();

        protected internal abstract TDomain ToDomainObject(TData uniqueEntityData);

        internal async Task<List<TData>> RunSqlQueryAsync(IQueryable<TData> query) => await query.AsNoTracking().ToListAsync();

        protected internal virtual IQueryable<TData> CreateSqlQuery()
        {
            var query = from s in DbSet select s;

            return query;
        }

        public async Task<List<TDomain>> Get()
        {
            var query = CreateSqlQuery();
            var set = await RunSqlQueryAsync(query);

            return ToDomainObjectsList(set);
        }

        public async Task<TDomain> Get(string id)
        {
            var data = await GetData(id);
            var obj = ToDomainObject(data);
            return obj;
        }

        public async Task Delete(string id)
        {
            var data = await GetData(id);

            DbSet.Remove(data);
            await DbContext.SaveChangesAsync();
        }

        public async Task Add(TDomain obj)
        {
            var data = GetData(obj);
            if (data is null) return;
            if (IsInDatabase(data)) await Update(obj);
            else await DbSet.AddAsync(data);

            await DbContext.SaveChangesAsync();
        }

        public async Task Update(TDomain obj)
        {
            var data = GetData(obj);
            data = CopyData(data);
            DbContext.Attach(data).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
        }

        public object GetById(string id)
        {
            return Get(id).GetAwaiter().GetResult();
        }

        protected TData GetData(TDomain obj) => obj?.Data;
        
        protected abstract TData GetDataById(TData data);

        protected bool IsInDatabase(TData data) => GetDataById(data) != null;

        private TData CopyData(TData data) {
            var x = GetDataById(data);

            if (x is null) return data;
            Copy.Members(data, x);

            return x;
        }
    }
}
