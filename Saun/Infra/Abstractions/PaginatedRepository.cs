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
    }
}