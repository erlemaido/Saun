using System;
using Data.Abstractions;
using Data.CatalogItems;

namespace Data.Stocks
{
    public class StockData : UniqueEntityData
    {
        public Guid CatalogItemId { get; set; }
        public CatalogItemData CatalogItemData { get; set; } = null!;

        public int InStock { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string? Comment { get; set; }
    }
}