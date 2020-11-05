using System;
using System.Linq;
using System.Linq.Expressions;
using Data.Abstractions;
using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Abstractions
{
    public abstract class FilteredRepository<TDomain, TData> : SortedRepository<TDomain, TData>, IFiltering
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }

        protected FilteredRepository(DbContext c, DbSet<TData> s) : base(c, s)
        {
        }

        protected internal override IQueryable<TData> CreateSqlQuery()
        {
            var query = base.CreateSqlQuery();
            query = AddFixedFiltering(query);
            query = AddFiltering(query);

            return query;
        }

        protected internal IQueryable<TData> AddFixedFiltering(IQueryable<TData> query)
        {
            var expression = CreateFixedWhereExpression();
            return expression is null ? query : query.Where(expression);
        }

        protected internal Expression<Func<TData, bool>> CreateFixedWhereExpression()
        {
#pragma warning disable CS8603 // Possible null reference return.
            if (FixedFilter is null) return null;
#pragma warning restore CS8603 // Possible null reference return.
#pragma warning disable CS8603 // Possible null reference return.
            if (FixedValue is null) return null;
#pragma warning restore CS8603 // Possible null reference return.

            var param = Expression.Parameter(typeof(TData), "s");

            var p = typeof(TData).GetProperty(FixedFilter);

#pragma warning disable CS8603 // Possible null reference return.
            if (p is null) return null;
#pragma warning restore CS8603 // Possible null reference return.

            Expression body = Expression.Property(param, p);
            if (p.PropertyType != typeof(string))
            {
                body = Expression.Call(body, "ToString", null);
            }

            body = Expression.Equal(body, Expression.Constant(FixedValue));
            var predicate = body;

            return Expression.Lambda<Func<TData, bool>>(predicate, param);
        }

        internal IQueryable<TData> AddFiltering(IQueryable<TData> query)
        {
            if (string.IsNullOrEmpty(SearchString)) return query;
            var expression = CreateWhereExpression();
            return query.Where(expression);
        }

        internal Expression<Func<TData, bool>> CreateWhereExpression()
        {
#pragma warning disable CS8603 // Possible null reference return.
            if (string.IsNullOrWhiteSpace(SearchString)) return null;
#pragma warning restore CS8603 // Possible null reference return.

            var param = Expression.Parameter(typeof(TData), "s");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            Expression predicate = null;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

            foreach (var p in typeof(TData).GetProperties())
            {
                Expression body = Expression.Property(param, p);
                if (p.PropertyType != typeof(string))
                {
                    body = Expression.Call(body, "ToString", null);
                }

                body = Expression.Call(body, "Contains", null, Expression.Constant(SearchString));
                predicate = predicate is null ? body : Expression.Or(predicate, body);
            }

#pragma warning disable CS8603 // Possible null reference return.
            return predicate is null ? null : Expression.Lambda<Func<TData, bool>>(predicate, param);
#pragma warning restore CS8603 // Possible null reference return.
        }
    }
}