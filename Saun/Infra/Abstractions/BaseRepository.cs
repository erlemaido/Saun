using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Abstractions;
using Domain.Abstractions;

namespace Infra.Abstractions
{
    public abstract class BaseRepository<TDomain, TData> : ICrudMethods<TDomain>, IRepository
    where TDomain : IUniqueEntity<TData>
    where TData : UniqueEntityData, new()
    {
        public Task<List<TDomain>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TDomain> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Add(TDomain obj)
        {
            throw new NotImplementedException();
        }

        public Task Update(TDomain obj)
        {
            throw new NotImplementedException();
        }

        public object GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}