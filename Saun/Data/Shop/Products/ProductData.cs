using Data.Abstractions;

namespace Data.Shop.Products
{
    public class ProductData : DefinedEntityData
    {
        public string BrandId { get; set; }
        public string ProductTypeId { get; set; }
        public string UnitId { get; set; }
        public string PictureUrl { get; set; }
        public double Price { get; set; }
    }
}