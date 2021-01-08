using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Abstractions;
using Domain.Abstractions;

namespace Tests {

    internal abstract class UniqueRepository<TObj, TData>
        where TObj : UniqueEntity<TData>
        where TData : UniqueEntityData, new() {

        internal readonly List<TObj> list;
        public object GetById(string id) => null;

        protected UniqueRepository() {
            list = new List<TObj>();
        }

        public async Task<List<TObj>> Get() {
            await Task.CompletedTask;

            if (FixedFilter is null) return list;
            var l = new List<TObj>();
            var p = typeof(TData).GetProperty(FixedFilter);
            foreach (var e in list) {
                var v = p?.GetValue(e.Data);
                if (v is null) continue;
                if (v.ToString() != FixedValue) continue;
                l.Add(e);
            }
            return l;
        }

        public async Task<TObj> Get(string id) {
            await Task.CompletedTask;

            return list.Find(x => GetId(x.Data) == id);
        }

        protected abstract string GetId(TData d);

        public async Task Delete(string id) {
            await Task.CompletedTask;
            var obj = list.Find(x => GetId(x.Data) == id);
            list.Remove(obj);
        }

        public async Task Add(TObj obj) {
            await Task.CompletedTask;
            list.Add(obj);
        }

        public async Task Update(TObj obj) {
            await Delete(GetId(obj.Data));
            list.Add(obj);
        }

        public string SortOrder { get; set; }

        public string SearchString { get; set; }
        public string CurrentFilter { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }


    }

}