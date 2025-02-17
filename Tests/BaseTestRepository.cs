﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Abstractions;
using Domain.Abstractions;

namespace Tests
{
    internal class BaseTestRepository<TObj,TData> where TObj:UniqueEntity<TData> where TData:UniqueEntityData, new()
    {
        internal readonly List<TObj> list;

        public BaseTestRepository()
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
            return list.Find(x=>x.Data.Id == id);
        }

        public async Task Delete(string id)
        {
            await Task.CompletedTask;
            var obj = list.Find(x => x.Data.Id == id);
            list.Remove(obj);
        }

        public async Task Add(TObj obj)
        {
            await Task.CompletedTask;
            list.Add(obj);
        }

        public async Task Update(TObj obj)
        {
            await Delete(obj.Data.Id);
            list.Add(obj);
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public string SortOrder { get; set; }
        public string SearchString { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }
    }
}