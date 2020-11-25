using System;

namespace Domain.Abstractions
{
    public interface IUniqueEntity
    {
        String Id { get; }
    }

    public interface IUniqueEntity<out TData> : IUniqueEntity
    {
        TData Data { get; }
    }
}