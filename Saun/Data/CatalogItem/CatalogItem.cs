using Data.Abstractions;

namespace Data.CatalogItem
{
    public class CatalogItem : DefinedEntityData
    {
        public int CatalogItemBrandId { get; set; }
        public int CatalogItemTypeId { get; set; }
        public int UnitId { get; set; }
        public string PictureUrl { get; set; } = null!;
        public double Price { get; set; }
    }
}