using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Abstractions;
using Facade.Abstractions;

namespace Sauna.Pages.Abstractions {

    public abstract class PagedPage<TRepository, TDomain, TView, TData> :
        CrudPage<TRepository, TDomain, TView, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging
        where TView : UniqueEntityView
    {

        protected PagedPage(TRepository repository) : base(repository)
        {
            Items = new List<TView>();
        }

        public IList<TView> Items { get; private set; }

        public string SelectedId 
        {
            get;
            set;
        }
        public int PageIndex {
            get => Repository.PageIndex;
            set => Repository.PageIndex = value;
        }
        public bool HasPreviousPage => Repository.HasPreviousPage;
        public bool HasNextPage => Repository.HasNextPage;
        public int TotalPages => Repository.TotalPages;

        protected internal override void SetPageValues(string sortOrder, 
            string searchString, in int? pageIndex) {
            SortOrder = sortOrder;
            SearchString = searchString;
            PageIndex = pageIndex ?? 0;
        }

        protected internal async Task GetList(string sortOrder, 
            string currentFilter, string searchString,
            int? pageIndex, string fixedFilter, string fixedValue) {

            FixedFilter = fixedFilter;
            FixedValue = fixedValue;
            SortOrder = sortOrder;
            SearchString = GetSearchString(currentFilter, searchString, ref pageIndex);
            CurrentFilter = GetCurrentFilter(currentFilter, searchString, ref pageIndex);
            PageIndex = pageIndex ?? 1;
            Items = await GetList().ConfigureAwait(true);
        }

        internal async Task<List<TView>> GetList() {
            var list = await Repository.Get().ConfigureAwait(true);

            return list.Select(ToView).ToList();
        }
    }
}