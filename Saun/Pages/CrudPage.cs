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
        
        public string ItemId => Item?.GetId() ?? string.Empty;

        protected internal async Task<bool> AddObject(string fixedFilter, string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);
            
            if (!ModelState.IsValid) return false;
            await Repository.Add(ToObject(Item)).ConfigureAwait(true);
            
            return true;
        }
        
        protected internal async Task<bool> AddObject(string sortOrder, string searchString,
            int? pageIndex, string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            return await AddObject(fixedFilter, fixedValue).ConfigureAwait(true);
        }
        
        protected internal async Task<bool> UpdateObject(string fixedFilter, string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);
            
            if (!ModelState.IsValid) return false;
            await Repository.Update(ToObject(Item)).ConfigureAwait(true);

            return true;
        }
        
        protected internal async Task<bool> UpdateObject(string sortOrder, 
            string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            return await UpdateObject(fixedFilter, fixedValue).ConfigureAwait(true);
        }
        
        protected internal async Task GetObject(string id, string fixedFilter, 
            string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);
            var obj = await Repository.Get(id);
            Item = ToView(obj);
        }

        protected internal async Task GetObject(string id, string sortOrder, 
            string searchString, int? pageIndex, string fixedFilter, string fixedValue) {
            SetPageValues(sortOrder, searchString, pageIndex);
            await GetObject(id, fixedFilter, fixedValue).ConfigureAwait(true);
        }

        protected internal async Task DeleteObject(string id, string fixedFilter, 
            string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);
            await Repository.Delete(id).ConfigureAwait(true);
        }
        
        protected internal async Task DeleteObject(string id, string sortOrder, 
            string searchString, int? pageIndex, string fixedFilter, string fixedValue)
        {
            SetPageValues(sortOrder, searchString, pageIndex);
            await DeleteObject(id, fixedFilter, fixedValue).ConfigureAwait(true);
        }

        protected internal abstract TDomain ToObject(TView view);

        protected internal abstract TView ToView(TDomain obj);

    }

}
