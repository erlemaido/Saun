using System;
using Data.Abstractions;
using Data.Products;

namespace Data.Stocks
{
    public class StockData : UniqueEntityData
    {
        public String ProductId { get; set; }
        public ProductData ProductData { get; set; }

        public int InStock { get; set; }
        public DateTime LastUpdateTime { get; set; }
        public string Comment { get; set; }
    }
}