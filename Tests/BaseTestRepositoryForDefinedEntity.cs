using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Abstractions;
using Domain.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    internal abstract class BaseTestRepositoryForDefinedEntity<TObj, TData> where TObj : DefinedEntity<TData> where TData : DefinedEntityData, new()
    {
        internal readonly List<TObj> list;

        public BaseTestRepositoryForDefinedEntity()
        {
            list = new List<TObj>();
        }

        public async Task<List<TObj>> Get()
        {
            await Task.CompletedTask;
            return list;
        }

        public async Task<TObj> Get(string id)
        {
            await Task.CompletedTask;
            return list.Find(x => IsThis(x, id));
        }

        public async Task Delete(string id)
        {
            await Task.CompletedTask;
            var obj = list.Find(x => IsThis(x, id));
            list.Remove(obj);
        }

        protected abstract bool IsThis(TObj entity, string id);

        public async Task Add(TObj obj)
        {
            await Task.CompletedTask;
            list.Add(obj);
        }

        public async Task Update(TObj obj)
        {
            await Delete(GetId(obj));
            list.Add(obj);
        }

        protected abstract string GetId(TObj entity);

        public string SortOrder { get; set; }
        public string SearchString { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}
