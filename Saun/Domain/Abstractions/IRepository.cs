using System;

namespace Saun.Domain.Abstractions
{
    public interface IRepository<T> : ICrudMethods<T>, IPaging, IFiltering, ISorting, IRepository 
    {
        
    }

    public interface IRepository
    {
        object GetById(Guid id);
    }
}