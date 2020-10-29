using System;
using Saun.Data.Abstractions;

namespace Saun.Data.Stock
{
    public class StockData : UniqueEntityData
    {
        public Guid CatalogItemId { get; set; }
        public int InStock { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string? Comment { get; set; }
    }
}