﻿using System.Threading.Tasks;
using Domain.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Pages {

    public abstract class CrudPage<TRepository, TDomain, TView, TData> :
        BasePage<TRepository, TDomain, TView, TData>
        where TRepository : ICrudMethods<TDomain>, ISorting, IFiltering, IPaging {

        protected CrudPage(TRepository repository) : base(repository) { }

        [BindProperty]
        public TView Item { get; set; }

        protected internal async Task<bool> AddObject(string fixedFilter, string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);

            try {
                if (!ModelState.IsValid) return false;
                await Repository.Add(ToObject(Item));
            }
            catch { return false; }

            return true;
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

        protected internal async Task<bool> UpdateObject(string id, string fixedFilter, string fixedValue)
        {
            SetFixedFilter(fixedFilter, fixedValue);

            try
            {
                if (!ModelState.IsValid) return false;
                //               await Repository.Delete(id);
                await Repository.Add(ToObject(Item));
            }
            catch { return false; }

            return true;
        }

        protected internal async Task GetObject(string id, string fixedFilter, string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);
            //           var o = await Repository.Get(id);
            //           Item = ToView(o);
        }

        protected internal async Task GetObject(string id, string sortOrder, string searchString, int pageIndex, string fixedFilter, string fixedValue) {
            SetPageValues(sortOrder, searchString, pageIndex);
            SetFixedFilter(fixedFilter, fixedValue);
            //            var o = await Repository.Get(id);
            //            Item = ToView(o);
        }

        protected internal async Task DeleteObject(string id, string fixedFilter, string fixedValue) {
            SetFixedFilter(fixedFilter, fixedValue);
            //            await Repository.Delete(id);
        }

        protected internal abstract TDomain ToObject(TView view);

        protected internal abstract TView ToView(TDomain obj);

    }

}
