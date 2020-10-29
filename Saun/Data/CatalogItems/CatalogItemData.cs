using System;
using Data.Abstractions;

namespace Data.CatalogItems
{
    public class CatalogItemData : DefinedEntityData
    {
        public Guid CatalogItemBrandId { get; set; }
        public Guid CatalogItemTypeId { get; set; }
        public Guid UnitId { get; set; }
        public string PictureUrl { get; set; } = null!;
        public double Price { get; set; }
    }
}