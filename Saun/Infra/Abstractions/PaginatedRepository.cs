using System;
using System.Linq;
using Data.Abstractions;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Abstractions
{
    public abstract class PaginatedRepository<TDomain, TData> : FilteredRepository<TDomain, TData>, IPaging
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }

        protected PaginatedRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
        }

        internal int GetTotalPages(in int pageSize)
        {
            var count = GetItemsCount();
            var pages = CountTotalPages(count, pageSize);

            return pages;
        }

        internal int CountTotalPages(int count, in int pageSize) => (int)Math.Ceiling(count / (double)pageSize);

        internal int GetItemsCount() => base.CreateSqlQuery().CountAsync().Result;

        protected internal override IQueryable<TData> CreateSqlQuery() => AddSkipAndTake(base.CreateSqlQuery());

        protected internal IQueryable<TData> AddSkipAndTake(IQueryable<TData> query)
        {
            if (PageIndex < 1) return query;
            return query
                .Skip((PageIndex - 1) * PageSize)
                .Take(PageSize);
        }
    }
}