using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstractions;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Abstractions
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>, IRepository
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        protected internal DbContext db;
        protected internal DbSet<TData> dbSet;

        protected BaseRepository(DbContext c, DbSet<TData> s)
        {
            db = c;
            dbSet = s;
        }
        protected abstract Task<TData> GetData(Guid id);
        protected abstract Guid GetId(TDomain entity);
        internal List<TDomain> ToDomainObjectsList(List<TData> set) => set.Select(ToDomainObject).ToList();

        protected internal abstract TDomain ToDomainObject(TData periodData);

        internal async Task<List<TData>> RunSqlQueryAsync(IQueryable<TData> query) => await query.AsNoTracking().ToListAsync();

        protected internal virtual IQueryable<TData> CreateSqlQuery()
        {
            var query = from s in dbSet select s;

            return query;
        }

        public async Task<List<TDomain>> Get()
        {
            var query = CreateSqlQuery();
            var set = await RunSqlQueryAsync(query);

            return ToDomainObjectsList(set);
        }

        public async Task<TDomain> Get(Guid id)
        {
            var d = await GetData(id);
            var obj = ToDomainObject(d);
            return obj;
        }

        public async Task Delete(Guid id)
        {
            var d = await GetData(id);

            dbSet.Remove(d);
            await db.SaveChangesAsync();
        }

        public async Task Add(TDomain obj)
        {
            if (obj?.Data is null) return;
            dbSet.Add(obj.Data);
            await db.SaveChangesAsync();
        }

        public async Task Update(TDomain obj)
        {
            var v = await GetData(GetId(obj));
            dbSet.Remove(v);
            dbSet.Add(obj.Data);
            await db.SaveChangesAsync();
        }

        public object GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
