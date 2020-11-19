using System;
using System.Collections.Generic;
using System.Linq;
using Data.Abstractions;
using Domain.Abstractions;
using Facade.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pages
{
    public abstract class TitledPage<TRepository, TDomain, TView, TData> :
        PagedPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : UniqueEntityView
    {

        protected internal TitledPage(TRepository repository, string title) : base(repository) => PageTitle = title;

        public string PageTitle { get; }

        public string PageSubTitle => FixedValue is null ? string.Empty : $"{PageSubtitle()}";

        protected internal virtual string PageSubtitle() => string.Empty;

        public Uri PageUrl => CreatePageUrl();
        public Uri CreationUrl => CreateCreationUrl();

        protected internal Uri CreateCreationUrl()
            => new Uri($"{PageUrl}/Create" +
                       "?handler=Create" +
                       $"&pageIndex={PageIndex}" +
                       $"&sortOrder={SortOrder}" +
                       $"&searchString={SearchString}" +
                       $"&fixedFilter={FixedFilter}" +
                       $"&fixedValue={FixedValue}", UriKind.Relative);

        protected internal abstract Uri CreatePageUrl();

        public Uri IndexUrl => CreateIndexUrl();

        protected internal Uri CreateIndexUrl() =>
            new Uri($"{PageUrl}/Index?handler=Index&fixedFilter={FixedFilter}&fixedValue={FixedValue}", UriKind.Relative);

        protected internal static IEnumerable<SelectListItem> NewItemsList<TTDomain, TTData>(IRepository<TTDomain> repository,
            Func<TTDomain, bool> condition = null)
            where TTDomain : IUniqueEntity<TTData>
            where TTData : NamedEntityData, new()
        {
            var items = repository?.Get().GetAwaiter().GetResult();
            var list = items is null
                ? new List<SelectListItem>()
                : condition is null ?
                    items
                    .Select(m => new SelectListItem(m.Data.Name, m.Data.Id.ToString()))
                    .ToList() :
                    items
                    .Where(condition)
                    .Select(m => new SelectListItem(m.Data.Name, m.Data.Id.ToString()))
                    .ToList();

            return list;
        }

        protected internal static string ItemName(IEnumerable<SelectListItem> list, Guid id)
        {
            return (from selectListItem in list where selectListItem.Value == id.ToString() select selectListItem.Text).FirstOrDefault();
        }

        public virtual bool IsMasterDetail() => PageSubTitle != string.Empty;

    }
    
}
