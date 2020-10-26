using System;
using Data.Abstractions;

namespace Data.Stock
{
    public class Stock : UniqueEntityData
    {
        public Guid CatalogItemId { get; set; }
        public int InStock { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string? Comment { get; set; }
    }
}