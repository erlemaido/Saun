using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Data.Abstractions;
using Domain.Abstractions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Infra.Abstractions
{
    public abstract class SortedRepository<TDomain, TData> : BaseRepository<TDomain, TData>, ISorting
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        public string DescendingString => "_desc";
        public string? SortOrder { get; set; }
        internal bool IsDescending() => !string.IsNullOrEmpty(SortOrder) && SortOrder.EndsWith(DescendingString);

        protected SortedRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
        }

        protected internal override IQueryable<TData> CreateSqlQuery()
        {
            var query = base.CreateSqlQuery();
            query = AddSorting(query);

            return query;
        }

        protected internal IQueryable<TData> AddSorting(IQueryable<TData> query)
        {
            var expression = CreateExpression();
            var r = expression is null ? query : AddOrderBy(query, expression);
            return r;
        }

        internal Expression<Func<TData, object>> CreateExpression()
        {
            var property = FindProperty();
#pragma warning disable CS8603 // Possible null reference return.
            return property is null ? null : LambdaExpression(property);
#pragma warning restore CS8603 // Possible null reference return.
        }

        internal Expression<Func<TData, object>> LambdaExpression(PropertyInfo p)
        {
            var param = Expression.Parameter(typeof(TData), "x");
            var property = Expression.Property(param, p);
            var body = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TData, object>>(body, param);
        }

        internal PropertyInfo FindProperty()
        {
            var name = GetName();
            return typeof(TData).GetProperty(name);
        }

        internal string GetName()
        {
            if (string.IsNullOrEmpty(SortOrder)) return string.Empty;
            var idx = SortOrder.IndexOf(DescendingString, StringComparison.Ordinal);
            return idx > 0 ? SortOrder.Remove(idx) : SortOrder;
        }

        internal IQueryable<TData> AddOrderBy(IQueryable<TData> query, Expression<Func<TData, object>> e)
        {
#pragma warning disable CS8603 // Possible null reference return.
            if (query is null) return null;
#pragma warning restore CS8603 // Possible null reference return.
            if (e is null) return query;
            try
            {
                return IsDescending() ? query.OrderByDescending(e) : query.OrderBy(e);
            }
            catch
            {
                return query;
            }
        }
    }
}