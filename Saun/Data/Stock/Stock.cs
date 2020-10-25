using System;
using Data.Abstractions;

namespace Data.Stock
{
    public class Stock : UniqueEntityData
    {
        public int CatalogItemId { get; set; }
        public int InStock { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string? Comment { get; set; }
    }
}