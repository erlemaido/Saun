using System;
using System.Collections.Generic;
using System.Linq;
using Data.Abstractions;
using Data.Shop.People;
using Data.Shop.Units;
using Data.Shop.Users;
using Domain.Abstractions;
using Facade.Abstractions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sauna.Pages.Abstractions
{
    public abstract class TitledPage<TRepository, TDomain, TView, TData> :
        PagedPage<TRepository, TDomain, TView, TData>
        where TRepository : class, ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : UniqueEntityView
    {

        protected internal TitledPage(TRepository repository, string title) : base(repository) => PageTitle = title;

        public string PageTitle { get; }

        public string PageSubtitle => FixedValue is null ? string.Empty : $"{GetPageSubtitle()}";

        protected internal virtual string GetPageSubtitle() => string.Empty;

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
                    .Select(m => new SelectListItem(m.Data.Name, m.Data.Id))
                    .ToList() :
                    items
                    .Where(condition)
                    .Select(m => new SelectListItem(m.Data.Name, m.Data.Id))
                    .ToList();

            return list;
        }
        
        protected internal static IEnumerable<SelectListItem> NewUnitsList<TTDomain, TTData>(IRepository<TTDomain> repository,
            Func<TTDomain, bool> condition = null)
            where TTDomain : IUniqueEntity<TTData>
            where TTData : UnitData, new()
        {
            var items = repository?.Get().GetAwaiter().GetResult();
            var list = items is null
                ? new List<SelectListItem>()
                : condition is null ?
                    items
                        .Select(m => new SelectListItem(m.Data.Code, m.Data.Id))
                        .ToList() :
                    items
                        .Where(condition)
                        .Select(m => new SelectListItem(m.Data.Code, m.Data.Id))
                        .ToList();

            return list;
        }
        
        protected internal static IEnumerable<SelectListItem> NewPeopleList<TtDomain, TtData>(IRepository<TtDomain> repository,
            Func<TtDomain, bool> condition = null)
            where TtDomain : IUniqueEntity<TtData>
            where TtData : PersonData, new()
        {
            var items = repository?.Get().GetAwaiter().GetResult();
            var list = items is null
                ? new List<SelectListItem>()
                : condition is null ?
                    items
                        .Select(m => new SelectListItem(m.Data.FirstName + " " + m.Data.LastName, m.Data.Id))
                        .ToList() :
                    items
                        .Where(condition)
                        .Select(m => new SelectListItem(m.Data.FirstName + " " + m.Data.LastName, m.Data.Id))
                        .ToList();

            return list;
        }
        
        protected internal static IEnumerable<SelectListItem> NewUsersList<TtDomain, TtData>(IRepository<TtDomain> repository,
            Func<TtDomain, bool> condition = null)
            where TtDomain : IUniqueEntity<TtData>
            where TtData : UserData, new()
        {
            var items = repository?.Get().GetAwaiter().GetResult();
            var list = items is null
                ? new List<SelectListItem>()
                : condition is null ?
                    items
                        .Select(m => new SelectListItem(m.Data.Email, m.Data.Id))
                        .ToList() :
                    items
                        .Where(condition)
                        .Select(m => new SelectListItem(m.Data.Email, m.Data.Id))
                        .ToList();

            return list;
        }

        protected internal static string GetItemName(IEnumerable<SelectListItem> list, string id)
        {
            return (from selectListItem in list where selectListItem.Value == id select selectListItem.Text).FirstOrDefault();
        }

        public virtual bool IsMasterDetail() => PageSubtitle != string.Empty;
    }
}