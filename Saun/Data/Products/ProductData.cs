using Data.Abstractions;
using Data.Brands;
using Data.ProductTypes;
using Data.Units;

namespace Data.Products
{
    public class ProductData : DefinedEntityData
    {
        public string BrandDataId { get; set; }
        public BrandData BrandData { get; set; }

        public string ProductTypeDataId { get; set; }
        public ProductTypeData ProductTypeData { get; set; }

        public string UnitDataId { get; set; }
        public UnitData UnitData { get; set; }

        public string PictureUrl { get; set; }
        public double Price { get; set; }
    }
}