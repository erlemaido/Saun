using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Saun.Domain.Abstractions
{
    public interface ICrudMethods<T>
    {
        Task<List<T>> Get();
        Task<T> Get(Guid id);
        Task Delete(Guid id);
        Task Add(T obj);
        Task Update(T obj);
    }
}