using System;
using System.Threading.Tasks;
using Domain.Abstractions;
using Facade.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Pages {

    public abstract class CrudPage<TRepository, TDomain, TView, TData> :
        BasePage<TRepository, TDomain, TView, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : UniqueEntityView
    {
        
        protected CrudPage(TRepository repository) : base(repository) { }

        [BindProperty]
        public TView Item { get; set; }

        public Guid ItemId => Item?.GetId() ?? Guid.Empty;
        protected internal async Task<bool> AddObject(string fixedFilter, string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);

            try {
                if (!ModelState.IsValid) return false;
                await Repository.Add(ToObject(Item));
            }
            catch { return false; }

            return true;
        }
        protected internal async Task<bool> AddObject(string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            return await AddObject(fixedFilter, fixedValue).ConfigureAwait(true);
        }
        protected internal async Task<bool> UpdateObject(string fixedFilter, string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);

            try {
                if (!ModelState.IsValid) return false;
                await Repository.Update(ToObject(Item));
            }
            catch { return false; }

            return true;
        }

        protected internal async Task<bool> UpdateObject(Guid id, string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);

            try
            {
                if (!ModelState.IsValid) return false;
                await Repository.Delete(id);
                await Repository.Add(ToObject(Item));
            }
            catch { return false; }

            return true;
        }
        protected internal async Task<bool> UpdateObject(string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            return await UpdateObject(fixedFilter, fixedValue).ConfigureAwait(true);
        }
        protected internal async Task GetObject(Guid id, string fixedFilter, string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);
            var o = await Repository.Get(id);
            Item = ToView(o);
        }

        protected internal async Task GetObject(Guid id, string sortOrder, string searchString, int? pageIndex, string fixedFilter, string fixedValue) {
            SetPageValues(sortOrder, searchString, pageIndex);
            SetFixedFilter(fixedFilter, fixedValue);
            var o = await Repository.Get(id);
            Item = ToView(o);
        }

        protected internal async Task DeleteObject(Guid id, string fixedFilter, string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);
            await Repository.Delete(id);
        }
        protected internal async Task DeleteObject(Guid id, string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            await DeleteObject(id, fixedFilter, fixedValue).ConfigureAwait(true);
        }

        protected internal abstract TDomain ToObject(TView view);

        protected internal abstract TView ToView(TDomain obj);

    }

}
