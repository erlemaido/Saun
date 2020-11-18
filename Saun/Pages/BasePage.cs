using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Aids.Reflection;
using Domain.Abstractions;
using Facade.Abstractions;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Pages {

    public abstract class BasePage<TRepository, TDomain, TView, TData> :
        PageModel
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
    {

        protected TRepository Repository;

        protected internal BasePage(TRepository repository) => Repository = repository;

        public string SortOrder {
            get => Repository.SortOrder;
            set => Repository.SortOrder = value;
        }
        public string SearchString {
            get => Repository.SearchString;
            set => Repository.SearchString = value;
        }
        
        public string CurrentFilter {
            get => Repository.CurrentFilter;
            set => Repository.CurrentFilter = value;
        }
        
        public string FixedValue {
            get => Repository.FixedValue;
            set => Repository.FixedValue = value;
        }
        public string FixedFilter {
            get => Repository.FixedFilter;
            set => Repository.FixedFilter = value;
        }
        
        public bool HasFixedFilter => !string.IsNullOrWhiteSpace(FixedFilter);

        protected internal void SetFixedFilter(string fixedFilter, string fixedValue) {
            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
        }

        protected internal abstract void SetPageValues(string sortOrder, string searchString, in int? pageIndex);
        public string GetSortString(Expression<Func<TData, object>> e, string page)
        {
            var name = GetMember.Name(e);
            var sortOrder = GetSortOrder(name);

            return $"{page}?sortOrder={sortOrder}&currentFilter={SearchString}"
                   + $"&fixedFilter={FixedFilter}&fixedValue={FixedValue}";
        }
        public Uri GetSortString(Expression<Func<TData, object>> e, Uri page) {
            var name = GetMember.Name(e);
            var sortOrder = GetSortOrder(name);

            return new Uri(
                $"{page}?handler=Index&sortOrder={sortOrder}&currentFilter={CurrentFilter}&searchString={SearchString}"
                + $"&fixedFilter={FixedFilter}&fixedValue={FixedValue}", UriKind.Relative);        }

        protected internal virtual string GetSortOrder(string name) {
            if (string.IsNullOrEmpty(SortOrder)) return name;
            if (!SortOrder.StartsWith(name)) return name;
            if (SortOrder.EndsWith("_desc")) return name;

            return name + "_desc";
        }

        internal static string GetSearchString(string currentFilter, string searchString, ref int? pageIndex) {
            if (searchString != null) { pageIndex = 1; }
            else { searchString = currentFilter; }

            return searchString;
        }
        
        internal static string GetCurrentFilter(string currentFilter, string searchString, ref int? pageIndex) {
            if (searchString != currentFilter) { pageIndex = 1; }

            return searchString;
        }
        internal static void LoadDetails<TDetailObj, TDetailView, TMasterView>(IList<TDetailView> list,
            IRepository<TDetailObj> data, TMasterView item,
            string filter, Func<TDetailObj, TDetailView> create)
            where TMasterView : UniqueEntityView
        {

            LoadDetails(list, data,item?.GetId().ToString(), filter, create);
        }

        internal static void LoadDetails<TDetailObj, TDetailView>(IList<TDetailView> list,
            IRepository<TDetailObj> data, string value,
            string filter, Func<TDetailObj, TDetailView> create)
        {
            list.Clear();
            if (value is null) return;

            data.FixedFilter = filter;
            data.FixedValue = value;
            var l = data.Get().GetAwaiter().GetResult();

            foreach (var e in l) { list.Add(create(e)); }
        }
    }
}
