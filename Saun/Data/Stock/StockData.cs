using System;
using Data.Abstractions;
using Data.Products;

namespace Data.Stocks
{
    public class StockData : UniqueEntityData
    {
        public string ProductId { get; set; }
        public int InStock { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Comment { get; set; }
    }
}