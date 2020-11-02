using Data.Abstractions;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Abstractions
{
    public abstract class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        public string? SortOrder { get; set; }

        protected SortedRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
        }
    }
}