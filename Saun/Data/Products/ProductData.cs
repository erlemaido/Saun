using Data.Abstractions;
using Data.ProductTypes;
using Data.Reviews;
using Data.Units;

namespace Data.Products
{
    public class ProductData : DefinedEntityData
    {
        public string BrandId { get; set; }
        public ReviewData Brand { get; set; }

        public string ProductTypeId { get; set; }
        public ProductTypeData ProductType { get; set; }

        public string UnitId { get; set; }
        public UnitData Unit { get; set; }

        public string PictureUrl { get; set; }
        public double Price { get; set; }
    }
}