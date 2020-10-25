using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Abstractions
{
    public interface ICrudMethods<T>
    {
        Task<List<T>> Get();
        Task<T> Get(int id);
        Task Delete(int id);
        Task Add(T obj);
        Task Update(T obj);
    }
}