using System;
using Data.Abstractions;
using Data.Brands;
using Data.ProductTypes;
using Data.Units;

namespace Data.Products
{
    public class ProductData : DefinedEntityData
    {
        public Guid BrandId { get; set; }
        public BrandData BrandData { get; set; }

        public Guid ProductTypeId { get; set; }
        public ProductTypeData ProductTypeData { get; set; }

        public Guid UnitId { get; set; }
        public UnitData UnitData { get; set; }

        public string PictureUrl { get; set; }
        public double Price { get; set; }
    }
}